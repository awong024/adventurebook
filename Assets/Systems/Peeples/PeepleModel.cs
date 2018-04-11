﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeepleModel : ScriptableObject {
    [SerializeField] string name;
    [SerializeField] Attribute peepleType;
    [SerializeField] string gameText;
    [SerializeField] bool basePeeple;

    public string Name { get { return name; } }
    public Attribute PeepleType { get { return peepleType; } }
    public string GameText { get { return gameText; } }
    public bool BasePeeple { get { return basePeeple; } }
}
