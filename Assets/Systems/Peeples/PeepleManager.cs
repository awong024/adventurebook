using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeepleManager : MonoBehaviour {
    private const string PEEPLE_DIR = "ScriptableObjects/Peeples/";

    private List<Peeple> peepleLibrary = new List<Peeple>();

    public void LoadAllPeeples() {
        Object[] models = Resources.LoadAll(PEEPLE_DIR, typeof(PeepleModel));
        foreach(PeepleModel model in models) {
            peepleLibrary.Add(new Peeple(model));
        }
    }
}
