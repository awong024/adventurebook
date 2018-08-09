using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapController : MonoBehaviour {
  [SerializeField] GameObject nodeRowPrefab;
  [SerializeField] MapNode nodePrefab;
  [SerializeField] NodeLine nodeLinePrefab;

  private const int NUM_NODE_ROWS = 6;
  private const int MIN_NODES_PER_ROW = 2;
  private const int MAX_NODES_PER_ROW = 3;

  private Map map;

  public void CreateMap() {
    List<List<MapNode>> mapRows = new List<List<MapNode>>();

    for (int i = 0; i < NUM_NODE_ROWS; i++) {
      int numOfNodes = AdventureUtils.RollChance(65) ? MAX_NODES_PER_ROW : MIN_NODES_PER_ROW;
      GameObject nodeRow = Instantiate(nodeRowPrefab) as GameObject;
      nodeRow.transform.SetParent(transform, false);

      List<MapNode> mapNodes = new List<MapNode>();

      for (int k = 0; k < numOfNodes; k++) {
        MapNode node = (MapNode)Instantiate(nodePrefab) as MapNode;
        node.transform.SetParent(nodeRow.transform, false);
        node.Init(i + 1, k + 1);

        mapNodes.Add(node);
      }

      mapRows.Add(mapNodes);
    }

    this.map = new Map(mapRows);
    this.map.CreateNodeLinks(this.DrawLine);
  }

  private void DrawLine(MapNode sourceNode, MapNode destinationNode) {
    NodeLine line = (NodeLine)Instantiate(nodeLinePrefab) as NodeLine;
    line.transform.SetParent(sourceNode.transform, false);
    line.transform.SetAsFirstSibling();
    line.DrawNewLineBetween(sourceNode.gameObject, destinationNode.gameObject);
  }

  public class Map {
    public List<List<MapNode>> MapNodes { get; private set; }

    public Map(List<List<MapNode>> nodes) {
      this.MapNodes = nodes;
    }

    public void CreateNodeLinks(UnityAction<MapNode, MapNode> drawLine) {
      for (int i = 1; i < MapNodes.Count; i++) {
        List<MapNode> currentRow = GetMapRow(i);
        List<MapNode> nextRow = GetMapRow(i + 1);

        // Mandatory Links //

        // Link Top Nodes
        MapNode topNode1 = GetMapNode(i, 1);
        MapNode topNode2 = GetMapNode(i + 1, 1);
        CreateNodeLink(topNode1, topNode2, drawLine);

        // Link Bottom Nodes
        MapNode botNode1 = GetMapNode(i, currentRow.Count);
        MapNode botNode2 = GetMapNode(i + 1, nextRow.Count);
        CreateNodeLink(botNode1, botNode2, drawLine);

        // Nodes must have at least one Entrance Link
        foreach (MapNode node in nextRow) {
          if (node.EntranceNodes.Count == 0) {
            CreateValidLink(currentRow, node, drawLine, forwardLink: false);
          }
        }

        // Additional Links //

        // 2:2 Chance to create one path
        if (currentRow.Count == 2 && nextRow.Count == 2) {
          if (AdventureUtils.RollChance(50)) {
            CreateNodeLink(currentRow[0], nextRow[1], drawLine);
          } else {
            CreateNodeLink(currentRow[1], nextRow[0], drawLine);
          }
        }

        // 2:3 Next Middle-Node already has one path, chance to create another
        if (currentRow.Count == 2 && nextRow.Count == 3) {
          if (AdventureUtils.RollChance(50)) {
            if (nextRow[1].HasEntranceNode(1)) {
              CreateNodeLink(currentRow[1], nextRow[1], drawLine);
            } else {
              CreateNodeLink(currentRow[0], nextRow[1], drawLine);
            }
          }
        }

        // 3:2 Middle-Node draws a path, with chance for additional path
        if (currentRow.Count == 3 && nextRow.Count == 2) {
          if (AdventureUtils.RollChance(50)) {
            CreateNodeLink(currentRow[1], nextRow[0], drawLine);
            if (AdventureUtils.RollChance(50)) {
              CreateNodeLink(currentRow[1], nextRow[1], drawLine);
            }
          } else {
            CreateNodeLink(currentRow[1], nextRow[1], drawLine);
            if (AdventureUtils.RollChance(50)) {
              CreateNodeLink(currentRow[1], nextRow[0], drawLine);
            }
          }
        }

        // 3:3 Next Middle-Node already has one path, chance to create another
        if (currentRow.Count == 3 && nextRow.Count == 3) {
          if (nextRow[1].HasEntranceNode(1)) {
            // Draw path from Middle Node
            if (AdventureUtils.RollChance(50)) {
              CreateNodeLink(currentRow[1], nextRow[1], drawLine);

              // Chance to draw another from bottom
              if (AdventureUtils.RollChance(50)) {
                CreateNodeLink(currentRow[2], nextRow[1], drawLine);
              }

            } else {
              CreateNodeLink(currentRow[1], nextRow[2], drawLine);
            }
          }

          else if (nextRow[1].HasEntranceNode(2)) {
            // Chance to draw to top and bottom
            if (AdventureUtils.RollChance(25)) {
              CreateNodeLink(currentRow[1], nextRow[0], drawLine);
              CreateNodeLink(currentRow[1], nextRow[2], drawLine);
            } else {
              // Draw to top
              if (AdventureUtils.RollChance(50)) {
                CreateNodeLink(currentRow[1], nextRow[0], drawLine);

                if (AdventureUtils.RollChance(50)) {
                  CreateNodeLink(currentRow[2], nextRow[1], drawLine);
                }
              }

              // Draw to bottom
              else {
                CreateNodeLink(currentRow[1], nextRow[2], drawLine);

                if (AdventureUtils.RollChance(50)) {
                  CreateNodeLink(currentRow[0], nextRow[1], drawLine);
                }
              }
            }
          }

          else if (nextRow[1].HasEntranceNode(3)) {
            // Draw path from Middle Node
            if (AdventureUtils.RollChance(50)) {
              CreateNodeLink(currentRow[1], nextRow[1], drawLine);

              // Chance to draw another from top
              if (AdventureUtils.RollChance(50)) {
                CreateNodeLink(currentRow[0], nextRow[1], drawLine);
              }

            } else {
              CreateNodeLink(currentRow[1], nextRow[0], drawLine);
            }
          }
        }
      }
    }

    private void CreateValidLink(List<MapNode> adjacentRow, MapNode currentNode, UnityAction<MapNode, MapNode> drawLine, bool forwardLink) {
      List<MapNode> validNodes = new List<MapNode>();
      foreach (MapNode node in adjacentRow) {
        if (Mathf.Abs(node.Position - currentNode.Position) <= 1) {
          validNodes.Add(node);
        }
      }

      int randomIndex = Random.Range(0, validNodes.Count);
      if (forwardLink) {
        CreateNodeLink(currentNode, validNodes[randomIndex], drawLine);
      } else {
        CreateNodeLink(validNodes[randomIndex], currentNode, drawLine);
      }
    }

    private void CreateNodeLink(MapNode node1, MapNode node2, UnityAction<MapNode, MapNode> drawLine) {
      node1.AddExitNode(node2);
      drawLine(node1, node2);
    }

    public List<MapNode> GetMapRow(int row) {
      if (this.MapNodes.Count >= row) {
        return this.MapNodes[row - 1];
      }

      Debug.LogError("MapController: GetMapRow Failed (" + row + ")");
      return null;
    }

    public MapNode GetMapNode(int row, int position) {
      if (GetMapRow(row).Count >= position) {
        return this.GetMapRow(row)[position - 1];
      }

      Debug.LogError("MapController: GetMapNode Failed (" + row + ", " + position + ")");
      return null;
    }
  }
}
