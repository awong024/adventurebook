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
      int numOfNodes = UnityEngine.Random.Range(MIN_NODES_PER_ROW, MAX_NODES_PER_ROW + 1);
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

        //Link top nodes
        MapNode topNode1 = GetMapNode(i, 1);
        MapNode topNode2 = GetMapNode(i + 1, 1);
        CreateNodeLink(topNode1, topNode2);
        drawLine(topNode1, topNode2);

        //Link bottom nodes
        MapNode botNode1 = GetMapNode(i, currentRow.Count);
        MapNode botNode2 = GetMapNode(i + 1, nextRow.Count);
        CreateNodeLink(botNode1, botNode2);
        drawLine(botNode1, botNode2);
      }
    }

    private void CreateNodeLink(MapNode node1, MapNode node2) {
      node1.AddExitNode(node2);
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
