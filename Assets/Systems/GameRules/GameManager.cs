using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
  //UI
  [SerializeField] MapController mapController;
  [SerializeField] PeepleTray peepleTray;
  [SerializeField] CharacterSheet characterSheet;
  [SerializeField] EventPanel eventPanel;

  //Data Loaders and Stores
  private PeepleData peepleData;

  public enum Phase {
    ChooseStart,
    Movement,
    Event,
    Combat
  }

  private Phase currentPhase;

  private void Start() {
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
