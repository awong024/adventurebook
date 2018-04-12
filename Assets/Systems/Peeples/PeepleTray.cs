using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeepleTray : MonoBehaviour {
    [SerializeField] GameObject[] peepleSlots;
    [SerializeField] Transform peeplePlacementLayout;

    //Init to 7 blank Peeple Figurines
    [SerializeField] PeepleFigurine[] heldFigurines;

    private static PeepleTray instance;

    public static GameObject[] PeepleSlots { get { return instance.peepleSlots; } }

    public static PeepleFigurine[] HeldFigurines { get { return instance.heldFigurines; } }

	private void Awake() {
        instance = this;
	}

	private void Start() {
        //Test Peeples
        StartCoroutine(DelayedStart());
	}

    private IEnumerator DelayedStart() {
        yield return new WaitForEndOfFrame();
        SetPeepleToSlot(heldFigurines[0], 0);
        SetPeepleToSlot(heldFigurines[1], 1);
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
        }
        heldFigurines[index] = peeple;
    }
}
