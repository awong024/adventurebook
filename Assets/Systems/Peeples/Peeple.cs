using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peeple {
    private string name;
    private Attribute peepleType;
    private string gameText;

    private List<Ability> abilities = new List<Ability>();
    private bool base_peeple = false;

    public Peeple(PeepleModel model) {
        this.name = model.Name;
        this.peepleType = model.PeepleType;
        this.gameText = model.GameText;
        this.base_peeple = model.BasePeeple;
    }
}
