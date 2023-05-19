using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRecord {
    public Unit unit;
    public Tile tile;

    public ActionRecord(Unit unit, Tile tile) {
        this.unit = unit;
        this.tile = tile;
    }
}
