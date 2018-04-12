using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragManager : MonoBehaviour {
    [SerializeField] RectTransform dropZone; //For playing Peeples

    private static DragManager instance;

    private PeepleFigurine draggingPeeple = null;

    public static PeepleFigurine DraggingPeeple { get { return instance.draggingPeeple; } }

    public static RectTransform DropZone { get { return instance.dropZone; } }

	private void Awake() {
        instance = this;
	}
}
