using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeNetworkController : MonoBehaviour {
    [SerializeField] NodeNetworkView nodeNetworkView;
    [SerializeField] GameObject playerFigurinePrefab;

    List<List<NetworkNode>> networkNodes; //Mapped like 2D array [row, position]
    private PlayerFigurine playerFigurine;

    public List<List<NetworkNode>> NetworkNodes { get { return networkNodes; } }

    public void InitNewMap() {
        Map map = new Map();
        map.GenerateNodeMap();

        networkNodes = nodeNetworkView.GenerateNodeNetwork(map, this);

        CreateNodeLinks();
        //EventRules.PopulateEvents(networkNodes);

        PlacePlayerFigurine();
    }

    private void CreateNodeLinks() {
        for (int i = 0; i < networkNodes.Count - 1; i++) {
            for (int k = 0; k < networkNodes[i].Count; k++) {
                NetworkNode node = networkNodes[i][k];
                foreach(int exit in node.Node.ExitLinks) {
                    NetworkNode linkedNode = networkNodes[i + 1][exit];
                    node.CreateNodeLink(linkedNode);
                }
            }
        }
    }

    public void NodeClicked(NetworkNode node) {
        if (GameManager.ChooseStartingNode(node)) {
            MovePlayerFigurine(node);
        } else if (playerFigurine.CurrentNode.HasExitTo(node) && GameManager.ChooseNextNodePhase(node)) {
            MovePlayerFigurine(node);
        }
    }

    private void PlacePlayerFigurine() {
        GameObject figurine = GameObject.Instantiate(playerFigurinePrefab) as GameObject;
        playerFigurine = figurine.GetComponent<PlayerFigurine>();
        MovePlayerFigurine(networkNodes[0][0]);
    }

    private void MovePlayerFigurine(NetworkNode node) {
        playerFigurine.MoveToNode(node);
    }
}
