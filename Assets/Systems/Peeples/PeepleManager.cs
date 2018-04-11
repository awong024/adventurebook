using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeepleManager : MonoBehaviour {
    private const string STR_PEEPLE_DIR = "ScriptableObjects/Peeples/";

    private List<Peeple> peepleLibrary = new List<Peeple>();

    private void Awake() {
        LoadAllPeeples();
	}

    private void LoadAllPeeples() {
        Object[] models = Resources.LoadAll(STR_PEEPLE_DIR, typeof(PeepleModel));
        foreach(PeepleModel model in models) {
            peepleLibrary.Add(new Peeple(model));
        }
    }
}
