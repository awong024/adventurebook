using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Network Manager
//Peeple Data Manager
//Peeple Action Manager (Drawing and Playing Peeple)
//Character Sheet (Update information)

public class GameManager : MonoBehaviour {

    [SerializeField] NodeNetworkController nodeNetworkController;
    [SerializeField] PeepleManager peepleDataManager;
    [SerializeField] PeepleTray peepleTray;

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

    public static bool ChooseStartingNode(NetworkNode node) {
        if (instance.currentPhase == Phase.ChooseStart && node.Node.NodeRow == 0) {
            //Picked Starting Node
            instance.SetPhase(Phase.Event);
            PanelManager.DisplayEventPanel(node.Event);
            return true;
        }
        return false;
    }

    public static bool ChooseNextNodePhase(NetworkNode node) {
        if (instance.currentPhase == Phase.Movement) {
            instance.SetPhase(Phase.Event);
            PanelManager.DisplayEventPanel(node.Event);
            return true;
        }
        return false;
    }

    public static void EventCompleted() {
        instance.SetPhase(Phase.Movement);
    }

    public static void PlayPeeple(PeepleFigurine peepleFigurine) {
        
    }
}
