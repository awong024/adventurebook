using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggablePeeple : MonoBehaviour, IDragHandler, IDropHandler {
    [SerializeField] PeepleFigurine peepleFigurine;

    public void OnDrag(PointerEventData eventData)	{
        transform.position = eventData.position;
	}

	public void OnEndDrag(PointerEventData eventData) {
        
	}

    public void OnDrop(PointerEventData eventData) {
        if (RectTransformUtility.RectangleContainsScreenPoint(DragManager.DropZone, eventData.position)) {
            Debug.Log("Dropped in Zone");
        } else {
            Debug.Log("Dropped nowhere");
        }
        transform.localPosition = new Vector3(0, 0, 0);
    }
}
