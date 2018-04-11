using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFigurine : MonoBehaviour {
    private NetworkNode currentNode;

    public NetworkNode CurrentNode { get { return currentNode; } }

    public void MoveToNode(NetworkNode node) {
        currentNode = node;
        transform.SetParent(node.transform, false);
        transform.localPosition = new Vector3(0, 0, 0);
    }
}
