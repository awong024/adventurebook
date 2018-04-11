using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    private int monetaryValue;
}

public class Equipment : Item {
    public enum Slot {
        Wield,
        Head,
        Body,
        Boots,
        Relic //Rings, Amulets, Artifacts
    }
}

public class ConsumableItem : Item {
    private List<Ability> abilities;
}
