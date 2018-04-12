using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeepleManager : MonoBehaviour {
    private const string PEEPLE_DIR = "ScriptableObjects/Peeples/";

    private List<Peeple> peepleLibrary = new List<Peeple>();

    private List<Peeple> peeplePool = new List<Peeple>();

    public void LoadAllPeeples() {
        Object[] models = Resources.LoadAll(PEEPLE_DIR, typeof(PeepleModel));
        foreach(PeepleModel model in models) {
            peepleLibrary.Add(new Peeple(model));
        }
        InitPeeplePool();
    }

    private void InitPeeplePool() {
        foreach(Peeple peeple in peepleLibrary) {
            if (peeple.BaseSet) {
                peeplePool.Add(peeple);
            }
        }
    }
}
