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
    [SerializeField] EventManager eventManager;
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
        eventManager.LoadAllChallenges();
        eventManager.PopulateEvents(nodeNetworkController.NetworkNodes);

        SetPhase(Phase.ChooseStart);

        StartCoroutine(StartGameFlow());
    }

    private IEnumerator StartGameFlow() {
        //Let's Unity UI take a frame to setup
        yield return new WaitForEndOfFrame();

        DrawPeeple();
        DrawPeeple();
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

    private void DrawPeeple() {
        peepleTray.CreateNewPeeple(peepleDataManager.DrawPeepleFromPool());
    }

    public static void PlayPeeple(PeepleFigurine peepleFigurine) {
        
    }
}
