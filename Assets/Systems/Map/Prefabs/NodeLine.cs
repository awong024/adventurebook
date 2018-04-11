using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeLine : MonoBehaviour {
    private GameObject gameObject1;
    private GameObject gameObject2;

    public void DrawNewLineBetween(GameObject g1, GameObject g2) {
        LineRenderer line = this.gameObject.AddComponent<LineRenderer>();
        line.startWidth = 5f;
        line.endWidth = 5f;
        line.startColor = Color.black;
        line.endColor = Color.black;
        line.positionCount = 2;

        gameObject1 = g1;
        gameObject2 = g2;
    }

	private void Update() {
        LineRenderer line = GetComponent<LineRenderer>();
        line.SetPosition(0, gameObject1.transform.position);
        line.SetPosition(1, gameObject2.transform.position);
	}
}
