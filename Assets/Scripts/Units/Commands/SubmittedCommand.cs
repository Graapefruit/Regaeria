using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Serializable causes the list of this object to instantiate itself inside of Unit for some reason
//[System.Serializable]
public class SubmittedCommand {
    public UnitCommand command;
    public Tile tile;

    public SubmittedCommand(UnitCommand command, Tile tile) {
        this.command = command;
        this.tile = tile;
    }
}
