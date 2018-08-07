using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNode : MonoBehaviour {
  public int Row { get; private set; }
  public int Position { get; private set; }

  List<MapNode> ExitNodes = new List<MapNode>();

  public void Init(int row, int position) {
    this.Row = row;
    this.Position = position;
  }

  public void AddExitNode(MapNode node) {
    this.ExitNodes.Add(node);
  }
}
