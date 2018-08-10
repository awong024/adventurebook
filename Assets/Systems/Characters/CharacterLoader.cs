using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoader {
  private const string CHARACTER_DIR = "ScriptableObjects/Characters/";

  private List<Character> characterPool = new List<Character>();

  private void LoadAllCharacters() {
    Object[] models = Resources.LoadAll(CHARACTER_DIR, typeof(CharacterModel));

    foreach (CharacterModel model in models) {
      characterPool.Add(new Character(model));
    }
  }

  public Character DrawCharacterFromPool() {
    int random = UnityEngine.Random.Range(0, characterPool.Count);
    return characterPool[random];
  }
}
