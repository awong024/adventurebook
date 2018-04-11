using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Actualization of MapNode
public class NetworkNode : MonoBehaviour {
    [SerializeField] GameObject nodeLinePrefab;
    [SerializeField] Text coordinateLabel;
    [SerializeField] Text environmentLabel;
    [SerializeField] Text activityLabel;

    private MapNode mapNode;

    public MapNode Node { get { return mapNode; } }

    private List<NetworkNode> exitNodes = new List<NetworkNode>();

    private NodeNetworkController networkController;

    //Node Game Elements
    private Event nodeEvent;

    public Event Event { get { return nodeEvent; } }

    public void Init(MapNode mapNode, NodeNetworkController controller) {
        networkController = controller;
        this.mapNode = mapNode;
        coordinateLabel.text = "(" + mapNode.NodeRow + "," + mapNode.NodePosition + ")";
	}

    public bool HasExitTo(NetworkNode node) {
        foreach(NetworkNode exitNode in exitNodes) {
            if (node == exitNode) {
                return true;
            }
        }
        return false;
    }

    public void ClickNode() {
        networkController.NodeClicked(this);
    }

    public void CreateNodeLink(NetworkNode node) {
        exitNodes.Add(node);
        DrawLineTo(node);
    }

    private void DrawLineTo(NetworkNode destinationNode) {
        GameObject line = GameObject.Instantiate(nodeLinePrefab) as GameObject;
        line.transform.SetParent(transform, false);
        line.GetComponent<NodeLine>().DrawNewLineBetween(this.gameObject, destinationNode.gameObject);
    }

    public void LoadEvent(Event ev) {
        nodeEvent = ev;
        environmentLabel.text = ev.EnvironmentType.ToString();
        if (ev.Activity is Challenge) {
            activityLabel.text = "Challenge";
        } else if (ev.Activity is Encounter) {
            activityLabel.text = "Encounter";
        } else if (ev.Activity is Merchant) {
            activityLabel.text = "Merchant";
        } else {
            activityLabel.text = "";
        }

    }
}
