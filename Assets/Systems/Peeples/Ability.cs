using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The basis for Card Actions and Item Actions
public class Ability {
    public enum Type {
        Damage,
        GrantBuff,
        DrawCards,
    }
}

//Passive Abilities on Allies such as Tags
public class PassiveAbility {
    public enum Type {
        CombatAlly,
        Party
    }
}

public class Buff {
    
}