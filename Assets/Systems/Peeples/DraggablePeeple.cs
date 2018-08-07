using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggablePeeple : MonoBehaviour, IDragHandler, IDropHandler, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] PeepleFigurine peepleFigurine;

    private int slotIndex;
    private Vector3 currentPosition;

    public void SetSlotPosition(int newIndex, Vector3 position) {
        transform.localPosition = position;
        currentPosition = position;
        slotIndex = newIndex;
    }

    public void OnDrag(PointerEventData eventData)	{
        transform.position = eventData.position;
        transform.SetAsLastSibling();
	}

	public void OnEndDrag(PointerEventData eventData) {
        
	}

    public void OnDrop(PointerEventData eventData) {

        //Play a Peeple
        //if (RectTransformUtility.RectangleContainsScreenPoint(DragManager.DropZone, eventData.position)) {
        //    if (GameManager.PlayPeeple(peepleFigurine)) {
        //        PeepleTray.RemovePeeple(slotIndex);
        //        return;
        //    }
        //} else {
        //    //Rearrange in Peeple Tray
        //    for (int i = 0; i < PeepleTray.PeepleSlots.Length; i++) {
        //        GameObject slot = PeepleTray.PeepleSlots[i];
        //        if (RectTransformUtility.RectangleContainsScreenPoint(
        //            slot.transform as RectTransform, eventData.position)) {
        //            //Debug.Log("Drop " + gameObject.name + " from " + slotIndex + " to " + i);
        //            PeepleTray.PlacePeepleOnSlot(peepleFigurine, slotIndex, slot);
        //            return;
        //        }
        //    }
        //}

        ////Reset Position if no valid drop zone
        //transform.localPosition = currentPosition;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        PeepleTray.DisplayPeepleCard(peepleFigurine.Peeple);
    }

    public void OnPointerExit(PointerEventData eventData) {
        PeepleTray.HidePeepleCard();
    }
}
