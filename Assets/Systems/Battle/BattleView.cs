using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleView : MonoBehaviour {
  [SerializeField] BattleCharacterView myCharacterView;
  [SerializeField] BattleCharacterView enemyCharacterView;

  [SerializeField] BattleAbilityView[] battleAbilityViews;

  //Test
  [SerializeField] BattleAbilityModel testAbilityA;
  [SerializeField] BattleAbilityModel testAbilityB;
  [SerializeField] BattleAbilityModel testAbilityC;

  public void Render(Battle battle) {
    RenderMyTeam(battle.MyBattleCharacter);
    RenderEnemyTeam(battle.EnemyBattleCharacter);

    battleAbilityViews[0].Render(new BattleAbility(testAbilityA));
    battleAbilityViews[1].Render(new BattleAbility(testAbilityB));
    battleAbilityViews[2].Render(new BattleAbility(testAbilityC));
  }

  private void RenderMyTeam(BattleCharacter character) {
    myCharacterView.Init(character);
  }

  private void RenderEnemyTeam(BattleCharacter character) {
    enemyCharacterView.Init(character);
  }
}
