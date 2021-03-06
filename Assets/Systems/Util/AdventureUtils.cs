﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AdventureUtils {

  public static void Shuffle<T>(this IList<T> list) {
    int n = list.Count;
    while (n > 1) {
      n--;
      int k = UnityEngine.Random.Range(0, n);
      T value = list[k];
      list[k] = list[n];
      list[n] = value;
    }
  }

  public static bool RollChance(int chance) {
    int roll = UnityEngine.Random.Range(0, 100);
    return roll < chance;
  }
}
