using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAbility : Ability {
  public enum ManaRank {
    Gain,
    Cost
  }

  private ManaRank manaRank;
  private int manaValue;

  private List<BattleAbilityComponent> components = new List<BattleAbilityComponent>();

  //Accessors
  public ManaRank AbilityManaRank { get { return manaRank; } }
  public int AbilityManaValue { get { return manaValue; } }
  public List<BattleAbilityComponent> Components { get { return components; } }

  public BattleAbility(BattleAbilityModel model) {
    manaRank = model.ManaRank;
    manaValue = model.ManaValue;

    components = new List<BattleAbilityComponent>();
    foreach(BattleAbilityComponent component in components) {
      components.Add(component);
    }
  }

  public string GetRulesText() {
    return string.Format("Deal {0} damage", components[0].ComponentValue.ToString());
  }
}
