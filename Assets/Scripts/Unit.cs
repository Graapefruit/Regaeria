using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    public UnitBaseStats baseStats;
    public UnitStatBlock currentStats;

    void Awake() {
        currentStats = ScriptableObject.CreateInstance("UnitStatBlock") as UnitStatBlock;
        currentStats.initializeStats(baseStats);
    }
}
