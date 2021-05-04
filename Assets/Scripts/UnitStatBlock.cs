using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatBlock : ScriptableObject {
    public UnitBaseStats baseStats;
    public int currentHp;

    public void initializeStats(UnitBaseStats baseStats) {
        this.baseStats = baseStats;
        this.currentHp = baseStats.baseHp;
    }
}
