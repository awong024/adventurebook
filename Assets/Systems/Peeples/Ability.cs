using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The basis for Card Actions and Item Actions
public abstract class Ability {
  public enum Type {
    Battle,
    Adventure
  }

  private string abilityName;

  public string AbilityName { get { return abilityName; } }
}