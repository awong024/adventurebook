using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler {

    public void OnDrag(PointerEventData eventData) {
        transform.position = eventData.position;
	}

    public void OnEndDrag(PointerEventData eventData) {
        transform.localPosition = new Vector3(0, 0, 0);
    }
}
