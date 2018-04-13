using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour {
    [SerializeField] Image peepleArt;

    public void Render(Peeple peeple) {
        peepleArt.sprite = peeple.FullArt;
    }
 }
