using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Attribute {
  Strength,
  Dexterity,
  Intellect,
  Charisma
}

public class CharacterSheet : MonoBehaviour {
  //View
  [SerializeField] Text levelLabel;
  [SerializeField] Text strengthLabel;
  [SerializeField] Text dexterityLabel;
  [SerializeField] Text intellectLabel;
  [SerializeField] Text charismaLabel;

  //Base Attribute Stats
  const int BASE_STRENGTH = 6;
  const int BASE_DEXTERITY = 6;
  const int BASE_INTELLECT = 6;
  const int BASE_CHARISMA = 6;

  private int level = 1;

  private int strength;
  private int dexterity;
  private int intellect;
  private int charisma;

  //Accessors
  public int Level { get { return level; } }
  public int Strength { get { return strength; } }
  public int Dexterity { get { return dexterity; } }
  public int Intellect { get { return intellect; } }
  public int Charisma { get { return charisma; } }

  //Equipment & Items
  private InventoryManager inventoryManager;

  //Battle Abilities
  private BattleAbility battleAbilityA;
  private BattleAbility battleAbilityB;
  private BattleAbility battleAbilityC;

  //Upgrades
  public int bonus_str = 0;
  public int bonus_dex = 0;
  public int bonus_int = 0;
  public int bonus_cha = 0;

  private bool initialized = false;

  private void OnEnable() {
    if (!initialized) {
      InitBaseAttributes();
    } else {
      Render();
    }
  }

  public void InitBaseAttributes() {
    level = 1;
    strength = BASE_STRENGTH + UnityEngine.Random.Range(-2, 3);
    dexterity = BASE_DEXTERITY + UnityEngine.Random.Range(-2, 3);
    intellect = BASE_INTELLECT + UnityEngine.Random.Range(-2, 3);
    charisma = BASE_CHARISMA + UnityEngine.Random.Range(-2, 3);

    initialized = true;
    Render();
  }

  public void Render() {
    strengthLabel.text = bonus_str > 0 ? Strength.ToString() + " + " + bonus_str.ToString() : Strength.ToString();
    dexterityLabel.text = bonus_dex > 0 ? Dexterity.ToString() + " + " + bonus_dex.ToString() : Dexterity.ToString();
    intellectLabel.text = bonus_int > 0 ? Intellect.ToString() + " + " + bonus_int.ToString() : Intellect.ToString();
    charismaLabel.text = bonus_cha > 0 ? Charisma.ToString() + " + " + bonus_cha.ToString() : Charisma.ToString();
  }
}
