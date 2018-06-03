using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peeple {
  private string name;
  private Attribute peepleType;
  private string gameText;

  private List<Ability> abilities = new List<Ability>();
  private bool base_peeple = false;

  private Sprite portraitArt;
  private Sprite fullArt;

  //Accessors
  public string Name { get { return name; } }
  public Attribute PeepleType { get { return peepleType; } }
  public string GameText { get { return gameText; } }
  public List<Ability> Abilities { get { return abilities; } }
  public bool BaseSet { get { return base_peeple; } }

  public Sprite PortraitArt { get { return portraitArt; } }
  public Sprite FullArt { get { return fullArt; } }

  public Peeple(PeepleModel model) {
    this.name = model.Name;
    this.peepleType = model.PeepleType;
    this.gameText = model.GameText;
    this.base_peeple = model.BasePeeple;
    this.portraitArt = model.PortraitArt;
    this.fullArt = model.FullArt;
  }
}
