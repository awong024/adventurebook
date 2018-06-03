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
  private BattleCharacter myBattleCharacter;
  private BattleCharacter enemyBattleCharacter;

  public BattleCharacter MyBattleCharacter { get { return myBattleCharacter; } }
  public BattleCharacter EnemyBattleCharacter { get { return enemyBattleCharacter; } }

  public void InitBattle(CharacterSheet characterSheet, List<Peeple> myPeeples, Peeple enemyPeeple) {
    myBattleCharacter = new BattleCharacter(characterSheet);
    enemyBattleCharacter = new BattleCharacter(enemyPeeple, characterSheet.Level);
  }
}
