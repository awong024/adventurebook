using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour {
    public enum Phase {
        ChooseStart,
        Movement,
        Event, //Engaging Event, can't move
        Combat //??
    }

    private Phase phaseStatus;

    private static PhaseManager instance;

	private void Awake() {
        instance = this;
	}

    public static Phase PhaseStatus { get { return instance.phaseStatus; } }
}
