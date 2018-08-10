using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel : ScriptableObject {
    [SerializeField] string name;
    [SerializeField] string gameText;
    [SerializeField] bool basePeeple;
    [SerializeField] Sprite portraitArt;
    [SerializeField] Sprite fullArt;

    [SerializeField] int tier = 1;

    public string Name { get { return name; } }
    public string GameText { get { return gameText; } }
    public bool BasePeeple { get { return basePeeple; } }
    public Sprite PortraitArt { get { return portraitArt; } }
    public Sprite FullArt { get { return fullArt; } }
    public int Tier { get { return tier; } }
}
