using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    private const string CHALLENGE_DIR = "ScriptableObjects/Challenges/";

    private List<Challenge> challengeLibrary = new List<Challenge>();

    public void LoadAllChallenges() {
        Object[] models = Resources.LoadAll(CHALLENGE_DIR, typeof(ChallengeModel));
        foreach (ChallengeModel model in models) {
            challengeLibrary.Add(new Challenge(model));
        }
    }

    public Challenge DrawChallengeByType(Challenge.Type type) {
        List<Challenge> challenges = new List<Challenge>();
        foreach(Challenge challenge in challengeLibrary) {
            if (challenge.ChallengeType == type) {
                challenges.Add(challenge);
            }
        }
        int random = UnityEngine.Random.Range(0, challenges.Count);
        return challenges[random];
    }

    public void PopulateEvents(List<List<NetworkNode>> networkNodes) {
        for (int i = 0; i < networkNodes.Count; i++) {
            for (int k = 0; k < networkNodes[i].Count; k++) {
                NetworkNode node = networkNodes[i][k];
                node.LoadEvent(GenerateRandomEvent());
            }
        }
    }

    private const int ENV_TOWN_CHANCE = 30;
    private const int ENV_WILD_CHANCE = 30;
    private const int ENV_RUINS_CHANCE = 30;

    private Event GenerateRandomEvent() {
        Event ev = new Event();

        int fullTable = ENV_TOWN_CHANCE + ENV_WILD_CHANCE + ENV_RUINS_CHANCE;
        int roll = UnityEngine.Random.Range(0, fullTable);

        if (roll < ENV_TOWN_CHANCE) {
            Challenge challenge = DrawChallengeByType(Challenge.Type.Town);
            ev.GenerateTownEvent(challenge);
        }
        else if (roll < ENV_TOWN_CHANCE + ENV_WILD_CHANCE) {
            Challenge challenge = DrawChallengeByType(Challenge.Type.CombatCheck);
            ev.GenerateWildEvent(challenge);
        }
        else {
            Challenge challenge = DrawChallengeByType(Challenge.Type.Explore);
            ev.GenerateRuinsEvent(challenge);
        }
        return ev;
    }
}
