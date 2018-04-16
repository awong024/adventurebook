using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCharacterView : MonoBehaviour {
    private Image image;

    public void Init(BattleCharacter character) {
        image = GetComponent<Image>();

        if (character.SpriteArt != null) {
            image.sprite = character.SpriteArt;
        }
    }
}
