using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : Activity {
    private const string TEST_ENEMY = "ScriptableObjects/Peeples/STR/Gladiator";

    //Enemies
    public List<Peeple> Peeples = new List<Peeple>();

    //Reward

    public Encounter() {
        Object model = Resources.Load(TEST_ENEMY, typeof(PeepleModel));
        Peeples.Add(new Peeple((PeepleModel)model));
        Peeples.Add(new Peeple((PeepleModel)model));
        Peeples.Add(new Peeple((PeepleModel)model));
    }
}
