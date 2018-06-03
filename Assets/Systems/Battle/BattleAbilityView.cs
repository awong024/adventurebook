using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleAbilityView : MonoBehaviour {
  [SerializeField] Text manaRankLabel;
  [SerializeField] Text abilityRulesLabel;

  public void Render(BattleAbility ability) {
    manaRankLabel.text = (ability.AbilityManaRank == BattleAbility.ManaRank.Gain ? "+" : "-") + ability.AbilityManaValue;
    abilityRulesLabel.text = ability.GetRulesText();
  }
}
