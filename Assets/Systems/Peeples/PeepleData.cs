using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeepleData {
  private const string PEEPLE_DIR = "ScriptableObjects/Peeples/";

  private List<Peeple> peeplePool = new List<Peeple>();

  private void LoadAllPeeples() {
    Object[] models = Resources.LoadAll(PEEPLE_DIR, typeof(PeepleModel));

    foreach (PeepleModel model in models) {
      peeplePool.Add(new Peeple(model));
    }
  }

  public Peeple DrawPeepleFromPool() {
    int random = UnityEngine.Random.Range(0, peeplePool.Count);
    return peeplePool[random];
  }
}
