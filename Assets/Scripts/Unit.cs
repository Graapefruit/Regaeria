using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    public UnitBaseStats baseStats;
    public UnitStatBlock unitStats;

    void Awake() {
        unitStats = ScriptableObject.CreateInstance("UnitStatBlock") as UnitStatBlock;
        unitStats.initializeStats(baseStats);
        Debug.Log(unitStats.baseStats);
    }
}
