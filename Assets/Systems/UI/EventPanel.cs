using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventPanel : Panel {
  [SerializeField] Text titleLabel;
  [SerializeField] Image environmentImage;
  [SerializeField] Text eventDescription;
  [SerializeField] Text successChanceLabel;

  [SerializeField] BattleView battleView;

  [SerializeField] Button proceedButton;
  [SerializeField] Button dismissButton;

  [SerializeField] Sprite townArt;
  [SerializeField] Sprite wildArt;
  [SerializeField] Sprite ruinsArt;

  [SerializeField] Sprite strPanel;
  [SerializeField] Sprite dexPanel;
  [SerializeField] Sprite intPanel;
  [SerializeField] Sprite chaPanel;

  [SerializeField] GameObject[] peepleSlots;

  private Event currentEvent;
  private List<Peeple> peepleList = new List<Peeple>();

  private bool eventFinished = false;

  private int successRate = 70;

  private const int NUM_COMBAT_PEEPLE_SLOTS = 2;

  public override void Display() {
    GameManager.EnableCharacterSheet(true);
    base.Display();
  }

  public override void Dismiss() {
    GameManager.EnableCharacterSheet(false);
    base.Dismiss();
  }

  public void Render(Event nodeEvent) {
    currentEvent = nodeEvent;
    titleLabel.text = "Combat";
    environmentImage.sprite = EnvironmentToSprite(currentEvent.EnvironmentType);
    eventDescription.text = "";

    for (int i = 0; i < peepleSlots.Length; i++) {
      peepleSlots[i].SetActive(i < NUM_COMBAT_PEEPLE_SLOTS);
    }
    peepleList.Clear();
  }

  public void Render(Challenge challenge) {
    titleLabel.text = currentEvent.EnvironmentType.ToString();
    environmentImage.sprite = EnvironmentToSprite(currentEvent.EnvironmentType);
    eventDescription.text = currentEvent.Challenge.ChallengeName;

    for (int i = 0; i < peepleSlots.Length; i++) {
      if (i < currentEvent.Challenge.AttributeSlots.Length) {
        peepleSlots[i].SetActive(true);
        peepleSlots[i].GetComponent<Image>().sprite = AttributeToSprite(currentEvent.Challenge.AttributeSlots[i]);
      } else peepleSlots[i].SetActive(false);
    }

    eventFinished = false;
    SetButtons();
    successRate = 70 + UnityEngine.Random.Range(-5, 6);
    successChanceLabel.text = "Success: " + successRate.ToString() + "%";
  }

  public bool ContributePeeple(PeepleFigurine peeple) {
    for (int i = 0; i < peepleSlots.Length; i++) {
      if (peepleSlots[i].activeSelf &&
          peepleSlots[i].transform.childCount == 0) {
        peeple.transform.SetParent(peepleSlots[i].transform, false);
        peeple.transform.localPosition = new Vector3(0, 0, 0);

        peepleList.Add(peeple.Peeple);
        return true;
      }
    }

    //for (int i = 0; i < peepleSlots.Length; i++) {
    //    if (peepleSlots[i].activeSelf && 
    //        peepleSlots[i].transform.childCount == 0 &&
    //        currentEvent.Challenge.AttributeSlots[i] == peeple.Peeple.PeepleType) {
    //        peeple.transform.SetParent(peepleSlots[i].transform, false);
    //        peeple.transform.localPosition = new Vector3(0, 0, 0);

    //        CalculateSuccess();
    //        return true;
    //    }
    //}
    return false;
  }

  public void ProceedClicked() {
    Encounter encounter = currentEvent.Activity as Encounter;

    Battle battle = new Battle();
    battle.InitBattle(GameManager.CharacterSheet, peepleList, encounter.Peeple);

    battleView.gameObject.SetActive(true);
    battleView.Render(battle);

    //bool success = currentEvent.ProcessEvent();
    //eventFinished = true;
    //successChanceLabel.text = "";
    //RandomizeReward();

    //SetButtons();

    //GameManager.EventCompleted();
  }

  private void SetButtons() {
    dismissButton.gameObject.SetActive(eventFinished);
    proceedButton.gameObject.SetActive(!eventFinished);
  }

  private void CleanupSlots() {
    for (int i = 0; i < peepleSlots.Length; i++) {
      foreach (Transform child in peepleSlots[i].transform) {
        GameObject.DestroyObject(child.gameObject);
      }
      peepleSlots[i].SetActive(false);
    }
  }

  private Sprite AttributeToSprite(Attribute attribute) {
    if (attribute == Attribute.Strength) return strPanel;
    if (attribute == Attribute.Dexterity) return dexPanel;
    if (attribute == Attribute.Intellect) return intPanel;
    if (attribute == Attribute.Charisma) return chaPanel;
    return null;
  }

  private Sprite EnvironmentToSprite(EnvironmentType env) {
    if (env == EnvironmentType.Town) return townArt;
    if (env == EnvironmentType.Wild) return wildArt;
    if (env == EnvironmentType.Ruins) return ruinsArt;
    return null;
  }

  //DEMO only
  private void CalculateSuccess() {
    int successChance = successRate;
    for (int i = 0; i < peepleSlots.Length; i++) {
      if (peepleSlots[i].activeSelf && peepleSlots[i].transform.childCount > 0) {
        successChance += 15;
      }
    }
    successChanceLabel.text = "Success: " + successChance.ToString() + "%";
  }

  //DEMO only
  private void RandomizeReward() {
    int random = UnityEngine.Random.Range(0, 2);
    if (random == 0) {
      GameManager.GrantBonusStats();
      eventDescription.text = "Success! You found loot";
    } else {
      GameManager.DrawOnePeeple();
      GameManager.DrawOnePeeple();
      eventDescription.text = "You Recruited two new Peeples!";
    }
  }

}
