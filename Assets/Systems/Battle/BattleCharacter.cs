using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacter {
    private int base_health;
    private int base_attack;

    //Accessors
    public int Health { get { return base_health; } }
    public int Attack { get { return base_attack; } }
}
