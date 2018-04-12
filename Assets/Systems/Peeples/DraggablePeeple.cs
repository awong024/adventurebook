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

        //Play a Peeple
        if (RectTransformUtility.RectangleContainsScreenPoint(DragManager.DropZone, eventData.position)) {
            
        } else {
            //Rearrange in Peeple Tray
            foreach(GameObject slot in PeepleTray.PeepleSlots) {
                if (RectTransformUtility.RectangleContainsScreenPoint(
                    slot.transform as RectTransform, eventData.position)) {
                    
                }
            }
        }

        //Reset Position if no valid drop zone
        transform.localPosition = new Vector3(0, 0, 0);
    }
}
