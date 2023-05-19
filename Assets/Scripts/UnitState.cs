using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitState {
    public Unit unit;
    public Tile tile;

    public UnitState(Unit unit, Tile tile) {
        this.unit = unit;
        this.tile = tile;
    }
}
