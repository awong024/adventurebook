using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeepleTray : MonoBehaviour {
    [SerializeField] GameObject peepleFigurinePrefab;
    [SerializeField] GameObject[] peepleSlots;
    [SerializeField] Transform peepleLayer;
    [SerializeField] CardView cardView;

    [SerializeField] Sprite strPanel;
    [SerializeField] Sprite dexPanel;
    [SerializeField] Sprite intPanel;
    [SerializeField] Sprite chaPanel;
    [SerializeField] Sprite blankPanel;

    //Init to 7 blank Peeple Figurines
    [SerializeField] PeepleFigurine[] heldFigurines;

    private static PeepleTray instance;

    public static GameObject[] PeepleSlots { get { return instance.peepleSlots; } }

    public static PeepleFigurine[] HeldFigurines { get { return instance.heldFigurines; } }

	private void Awake() {
        instance = this;
	}

    public void CreateNewPeeple(Peeple peeple) {
        for (int i = 0; i < heldFigurines.Length; i++) {
            if (heldFigurines[i] == null) {
                GameObject fig = GameObject.Instantiate(instance.peepleFigurinePrefab, peepleLayer) as GameObject;
                PeepleFigurine figurine = fig.GetComponent<PeepleFigurine>();
                figurine.Render(peeple);

                SetPeepleToSlot(figurine, i);
                return;
            }
        }
    }

	public static void PlacePeepleOnSlot(PeepleFigurine peeple, int fromIndex, GameObject toSlot) {
        //Find Index of ToSlot
        for (int i = 0; i < PeepleSlots.Length; i++) {
            if (toSlot == PeepleSlots[i]) {
                PeepleFigurine tempPeep = instance.heldFigurines[i];
                instance.SetPeepleToSlot(peeple, i);
                //Debug.Log("Set " + peeple.gameObject.name + " to " + i);
                instance.SetPeepleToSlot(tempPeep, fromIndex);
                //Debug.Log("Set " + tempPeep.gameObject.name + " to " + fromIndex);
            }
        }
    }

    private void SetPeepleToSlot(PeepleFigurine peeple, int index) {
        if (peeple != null) {
            DraggablePeeple draggable = peeple.GetComponent<DraggablePeeple>();
            draggable.SetSlotPosition(index, PeepleSlots[index].transform.localPosition);
            heldFigurines[index] = peeple;
            peepleSlots[index].GetComponent<Image>().sprite = AttributeToSprite(peeple.Peeple.PeepleType);
        } else {
            RemovePeeple(index);
            peepleSlots[index].GetComponent<Image>().sprite = blankPanel;
        }
    }

    public static void RemovePeeple(int index) {
        HeldFigurines[index] = null;
        instance.peepleSlots[index].GetComponent<Image>().sprite = instance.blankPanel;
    }

    private Sprite AttributeToSprite(Attribute attribute) {
        if (attribute == Attribute.Strength) return strPanel;
        if (attribute == Attribute.Dexterity) return dexPanel;
        if (attribute == Attribute.Intellect) return intPanel;
        if (attribute == Attribute.Charisma) return chaPanel;
        return null;
    }

    public static void DisplayPeepleCard(Peeple peeple) {
        instance.cardView.gameObject.SetActive(true);
        instance.cardView.Render(peeple);
    }

    public static void HidePeepleCard() {
        instance.cardView.gameObject.SetActive(false);
    }
}
