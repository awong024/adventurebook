using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNode {
    //Potion in Row: 0 = Top, 1 = Middle, 2 = Bottom
    int node_position;
    int node_row_num;
    List<int> node_exit_links = new List<int>();

    public MapNode(int node_position, int node_row_num) {
        this.node_position = node_position;
        this.node_row_num = node_row_num;
    }

    //Require:
    //Encounter Type

    public void Init() {
        
    }

    //Accessors
    public int NodeRow { get { return node_row_num; } }
    public int NodePosition { get { return node_position; } }
    public List<int> ExitLinks { get { return node_exit_links; } }

    public void AddExitLink(int exit_link) {
        if (node_exit_links.Count == 2) {
            //Debug.LogError("MapNode Error: Node already contains 2 exits");
            return;
        }

        if (node_exit_links.Contains(exit_link)) {
            //Debug.LogError("MapNode Error: Node exit already exists");
            return;
        }

        node_exit_links.Add(exit_link);
    }

    public bool HasExitLinkTo(int exit_link) {
        foreach(int link in node_exit_links) {
            if (link == exit_link) {
                return true;
            }
        }
        return false;
    }
}
