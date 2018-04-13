using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour {
    [SerializeField] Text nameLabel;
    [SerializeField] Image peepleArt;

    public void Render(Peeple peeple) {
        nameLabel.text = peeple.Name;
        peepleArt.sprite = peeple.FullArt;
    }
 }
