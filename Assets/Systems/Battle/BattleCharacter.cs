using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacter {
  private int level;
  private int current_health;
  private int max_health;
  private int attack_stat;
  private int critical_strike;

  //Accessors
  public int Level { get { return level; } }
  public int Health { get { return current_health; } }
  public int MaxHealth { get { return max_health; } }
  public int Attack { get { return attack_stat; } }

  //View related
  public Sprite SpriteArt;

  private const int BASE_HEALTH = 100;
  private const int BASE_ATTACK = 20;
  private const int BASE_CRITICAL_CHANCE = 10;

  private const int PLAYER_HEALTH_PER_LEVEL = 25;
  private const int PLAYER_ATTACK_PER_LEVEL = 5;

  private const int PEEPLE_HEALTH_PER_LEVEL = 25;
  private const int PEEPLE_ATTACK_PER_LEVEL = 5;

  public BattleCharacter(CharacterSheet characterSheet) {
    this.level = characterSheet.Level;
    CalibratePlayer(characterSheet);
  }

  public BattleCharacter(Peeple peeple, int level) {
    this.level = level;
    CalibratePeeple(peeple);
    SpriteArt = peeple.FullArt;
  }

  private void CalibratePlayer(CharacterSheet characterSheet) {
    max_health = BASE_HEALTH + ((level - 1) * PLAYER_HEALTH_PER_LEVEL);
    current_health = BASE_HEALTH;

    attack_stat = BASE_ATTACK + ((level - 1) * PLAYER_ATTACK_PER_LEVEL);
    critical_strike = BASE_CRITICAL_CHANCE;
  }

  private void CalibratePeeple(Peeple peeple) {
    max_health = BASE_HEALTH + ((level - 1) * PEEPLE_HEALTH_PER_LEVEL);
    current_health = BASE_HEALTH;

    attack_stat = BASE_ATTACK + ((level - 1) * PEEPLE_ATTACK_PER_LEVEL);
    critical_strike = BASE_CRITICAL_CHANCE;
  }

  public bool IsDefeated { get { return current_health == 0; } }
}
