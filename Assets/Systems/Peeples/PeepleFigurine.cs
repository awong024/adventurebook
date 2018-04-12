using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PeepleFigurine : MonoBehaviour {

    private Peeple peeple;

    public Peeple Peeple { get { return peeple; } }

	public void Render(Peeple peeple) {
        this.peeple = peeple;
	}
}
