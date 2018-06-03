using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BattleAbilityComponent {
  public enum ComponentType {
    Damage
  }

  public ComponentType Type;
  public int ComponentValue;
}

public class BattleAbilityModel : ScriptableObject {
  [SerializeField] BattleAbility.ManaRank manaRank;
  [SerializeField] int manaValue;

  [SerializeField] BattleAbilityComponent[] abilityComponents;

  public BattleAbility.ManaRank ManaRank { get { return manaRank; } }
  public int ManaValue { get { return manaValue; } }

  public BattleAbilityComponent[] AbilityComponents { get { return abilityComponents; } }
}
