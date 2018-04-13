using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeLine : MonoBehaviour {
    private Image image;
    private GameObject g1;
    private GameObject g2;

    public void DrawNewLineBetween(GameObject g1, GameObject g2) {
        image = GetComponent<Image>();
        image.enabled = false;
        this.g1 = g1;
        this.g2 = g2;

        StartCoroutine(DelayedDraw());
    }

    private IEnumerator DelayedDraw() {
        yield return new WaitForEndOfFrame();
        DrawLines();
    }

	private void DrawLines()	{
        image.enabled = true;
        Vector3 pointA = g1.transform.position;
        Vector3 pointB = g2.transform.position;

        Vector3 differenceVector = pointB - pointA;

        RectTransform imageRectTransform = transform as RectTransform;
        float screenFactor = 1428f / Screen.width;

        imageRectTransform.sizeDelta = new Vector2(differenceVector.magnitude * screenFactor, 10f);
        imageRectTransform.pivot = new Vector2(0, 0.5f);
        imageRectTransform.position = pointA;
        float angle = Mathf.Atan2(differenceVector.y, differenceVector.x) * Mathf.Rad2Deg;
        imageRectTransform.rotation = Quaternion.Euler(0, 0, angle);
	}
}
