using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeepleTray : MonoBehaviour {
    [SerializeField] GameObject[] peepleSlots;

    private static PeepleTray instance;

    public static GameObject[] PeepleSlots { get { return instance.peepleSlots; } }

	private void Awake() {
        instance = this;
	}

    private void PlacePeepleOnSlot(PeepleFigurine peeple, int fromSlot, int toSlot) {
        //If slot has someone, swap to fromSlot

        peeple.transform.SetParent(peepleSlots[toSlot].transform, false);
        peeple.transform.localPosition = new Vector3(0, 0, 0);
    }
}
