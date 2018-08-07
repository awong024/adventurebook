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

    private const int ENV_TOWN_CHANCE = 30;
    private const int ENV_WILD_CHANCE = 30;
    private const int ENV_RUINS_CHANCE = 30;

    private Event GenerateRandomEvent() {
        Event ev = new Event();

        int fullTable = ENV_TOWN_CHANCE + ENV_WILD_CHANCE + ENV_RUINS_CHANCE;
        int roll = UnityEngine.Random.Range(0, fullTable);

        EnvironmentType environmentType;

        if (roll < ENV_TOWN_CHANCE) {
            environmentType = EnvironmentType.Town;
        }
        else if (roll < ENV_TOWN_CHANCE + ENV_WILD_CHANCE) {
            environmentType = EnvironmentType.Wild;
        }
        else {
            environmentType = EnvironmentType.Ruins;
        }
        ev.Init(environmentType, new Encounter());
        return ev;
    }
}
