using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRules {

    private const int ENV_TOWN_CHANCE = 30;
    private const int ENV_WILD_CHANCE = 30;
    private const int ENV_RUINS_CHANCE = 30;

    public static void PopulateEvents(List<List<NetworkNode>> networkNodes) {
        for (int i = 0; i < networkNodes.Count; i++) {
            for (int k = 0; k < networkNodes[i].Count; k++) {
                NetworkNode node = networkNodes[i][k];
                node.LoadEvent(GenerateRandomEvent());
            }
        }
    }

    private static Event GenerateRandomEvent() {
        Event ev = new Event();

        int fullTable = ENV_TOWN_CHANCE + ENV_WILD_CHANCE + ENV_RUINS_CHANCE;
        int roll = UnityEngine.Random.Range(0, fullTable);

        if (roll < ENV_TOWN_CHANCE) {
            ev.GenerateTownEvent();
        } else if (roll < ENV_TOWN_CHANCE + ENV_WILD_CHANCE) {
            ev.GenerateWildEvent();
        } else {
            ev.GenerateRuinsEvent();
        }
        return ev;
    }
}
