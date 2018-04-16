using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack {
    public Peeple Attacker;
    public Peeple Target;
    public int Damage;

    public Attack(Peeple attacker, Peeple target, int damage) {
        Attacker = attacker;
        Target = target;
        Damage = damage;
    }
}

public class Battle {
    private List<BattleCharacter> myTeam = new List<BattleCharacter>();
    private List<BattleCharacter> enemyTeam = new List<BattleCharacter>();

    public List<BattleCharacter> MyTeam { get { return myTeam; } }
    public List<BattleCharacter> EnemyTeam { get { return enemyTeam; } }

    public void InitBattle( CharacterSheet characterSheet,
                            List<Peeple> myPeeples,
                            List<Peeple> enemyPeeples) {
        
        myTeam.Add(new BattleCharacter(characterSheet, 0));
        for(int i = 0; i < myPeeples.Count; i++) {
            myTeam.Add(new BattleCharacter(myPeeples[i], characterSheet.Level, i + 1));
        }

        for(int i = 0; i < enemyPeeples.Count; i++) {
            enemyTeam.Add(new BattleCharacter(enemyPeeples[i], characterSheet.Level, i)); //Change Level to enemy Level
        }
    }

    private void ProcessTurn() {
        //Determine random turn order
        List<BattleCharacter> attackOrder = new List<BattleCharacter>(myTeam.Count + enemyTeam.Count);
        attackOrder.AddRange(myTeam);
        attackOrder.AddRange(enemyTeam);


        //Each unit attacks a random enemy

    }

    private void ProcessAttack() {
        
    }
}
