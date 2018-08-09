using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapNode : MonoBehaviour {
  [SerializeField] private Text label; 

  public int Row { get; private set; }
  public int Position { get; private set; }

  public List<MapNode> EntranceNodes { get; private set; }
  public List<MapNode> ExitNodes { get; private set; }

  public void Init(int row, int position) {
    this.Row = row;
    this.Position = position;

    ExitNodes = new List<MapNode>();
    EntranceNodes = new List<MapNode>();
  }

  public void AddExitNode(MapNode node) {
    if (this.ExitNodes.Contains(node)) {
      Debug.LogError("MapNode.AddExitNode Error: Duplicate Exit Node");
      Debug.Log("(" + this.Row + ", " + this.Position + ") adding (" + node.Row + ", " + node.Position + ")");
      return;
    }

    if (node == this) {
      Debug.LogError("MapNode.AddExitNode Error: MapNode cannot add itself as ExitNode");
      return;
    }

    this.ExitNodes.Add(node);
    node.AddEntranceNode(this);
  }

  public void AddEntranceNode(MapNode node) {
    this.EntranceNodes.Add(node);
  }

  public bool HasEntranceNode(int position) {
    foreach (MapNode node in this.EntranceNodes) {
      if (node.Position == position) {
        return true;
      }
    }

    return false;
  }
}
