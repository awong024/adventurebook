using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
  //UI
  [SerializeField] MapController mapController;

  //Data Loaders and Stores
  private CharacterLoader characterLoader;

  public enum Phase {
    ChooseStart,
    Movement,
    Event,
    Combat
  }

  private Phase currentPhase;

  private void Start() {
    InitData();
    InitGame();
  }

  private void InitData() {
    
  }

  private void InitGame() {
    mapController.CreateMap();
  }

  private void SetPhase(Phase phase) {
    currentPhase = phase;
  }
}
