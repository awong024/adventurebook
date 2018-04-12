﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Network Manager
//Peeple Data Manager
//Peeple Action Manager (Drawing and Playing Peeple)
//Character Sheet (Update information)

public class GameManager : MonoBehaviour {

    [SerializeField] NodeNetworkController nodeNetworkController;
    [SerializeField] PeepleManager peepleDataManager;

    public enum Phase {
        ChooseStart,
        Movement,
        Event, //Engaging Event, can't move
        Combat //??
    }

    private Phase currentPhase;

    private static GameManager instance;

	private void Awake() {
        instance = this;
	}

	private void Start() {
        InitGame();
	}

    private void InitGame() {
        nodeNetworkController.InitNewMap();
        peepleDataManager.LoadAllPeeples();

        SetPhase(Phase.ChooseStart);
    }

    private void SetPhase(Phase phase) {
        currentPhase = phase;
    }

    public static bool ChooseStartingNode() {
        return instance.currentPhase == Phase.ChooseStart;
    }

    public static bool ChooseNextNodePhase() {
        return instance.currentPhase == Phase.Movement;
    }

    public static void PlayPeeple(PeepleFigurine peepleFigurine) {
        
    }
}
