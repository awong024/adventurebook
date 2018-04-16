using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleView : MonoBehaviour {
    [SerializeField] BattleCharacterView[] myTeamCharacterViews;
    [SerializeField] BattleCharacterView[] enemyTeamCharacterViews;

    public void Render(Battle battle) {
        ClearBattleCharacters();
        RenderMyTeam(battle.MyTeam);
        RenderEnemyTeam(battle.EnemyTeam);
	}

    private void RenderMyTeam(List<BattleCharacter> characters) {
        for (int i = 0; i < characters.Count; i++) {
            myTeamCharacterViews[characters[i].Index].gameObject.SetActive(true);
            myTeamCharacterViews[characters[i].Index].Init(characters[i]);
        }
    }

    private void RenderEnemyTeam(List<BattleCharacter> characters) {
        for (int i = 0; i < characters.Count; i++) {
            enemyTeamCharacterViews[characters[i].Index].gameObject.SetActive(true);
            enemyTeamCharacterViews[characters[i].Index].Init(characters[i]);
        }
    }

    private void ClearBattleCharacters() {
        for (int i = 0; i < myTeamCharacterViews.Length; i++) {
            myTeamCharacterViews[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < enemyTeamCharacterViews.Length; i++) {
            enemyTeamCharacterViews[i].gameObject.SetActive(false);
        }
    }

    private void ProcessAction() {
        
    }
}
