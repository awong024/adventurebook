using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeNetworkView : MonoBehaviour {
    [SerializeField] GameObject nodeRowPrefab;
    [SerializeField] GameObject nodePrefab;

    public List<List<NetworkNode>> GenerateNodeNetwork(Map map, NodeNetworkController controller) {
        List<List<NetworkNode>> fullNetwork = new List<List<NetworkNode>>();

        //Actualize Map to GameObjects
        for (int i = 0; i < map.NodeRows.Count; i++) {
            List<NetworkNode> networkRow = new List<NetworkNode>();
            GameObject node_row = GameObject.Instantiate(nodeRowPrefab) as GameObject;
            node_row.transform.SetParent(transform, false);

            for (int k = 0; k < map.NodeRows[i].Nodes.Count; k++) {
                GameObject row_node = GameObject.Instantiate(nodePrefab) as GameObject;
                row_node.transform.SetParent(node_row.transform, false);

                NetworkNode networkNode = row_node.GetComponent<NetworkNode>();
                networkNode.Init(map.NodeRows[i].Nodes[k], controller);
                networkRow.Add(networkNode);
            }
            fullNetwork.Add(networkRow);
        }
        return fullNetwork;
	}
}
