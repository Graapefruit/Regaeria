using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    public UnitCard unitCard;
    public UnitStatus unitStatus;
    public SubmittedCommand[] submittedCommands;
    public VisualizedOrder visualizedOrder;
    public GameEvent orderChangedEvent;
    public int id;
    
    // TODO: Serialize this?
    public Tile Tile {
        get { return tile; }
        set {
            if (tile != null) {
                tile.unit = null;
            }
            tile = value;
            if (value != null) {
                tile.unit = this;
                transform.position = tile.transform.position;
            }
        }
    }
    private Tile tile;
    [SerializeField]
    private Tile editorTile;

    void Awake() {
        submittedCommands = new SubmittedCommand[GlobalDefines.INITIATIVES];

        if (unitStatus == null) {
            unitStatus = ScriptableObject.CreateInstance("UnitStatus") as UnitStatus;
            unitStatus.initializeStatus(unitCard);
        }
    }

    void OnValidate() {
        if (editorTile != null) {
            Tile = editorTile;
        }
    }

    public Tile getProjectedLocationAfterCommands() {
        Tile projectedTile = tile;

        for(int i = 0; i < GlobalDefines.INITIATIVES; i++) {
            if (unitCard.initiatives[i]) {
                if (submittedCommands[i] != null) {
                    projectedTile = submittedCommands[i].tile;
                }
            }
        }

        return projectedTile;
    }

    public int getRemainingUses(UnitCommand command) {
        int submittedOccurances = 0;

        for(int i = 0; i < GlobalDefines.INITIATIVES; i++) {
            if (unitCard.initiatives[i]) {
                submittedOccurances += ((submittedCommands[i] != null) && (submittedCommands[i].command == command) ? 1 : 0);
            }
        }

        return command.repeatability - submittedOccurances;
    }

    public void submitCommand(UnitCommand command, Tile tile) {
        int latestInitiative = getNextFreeInitiative();

        if (latestInitiative != -1) {
            SubmittedCommand newSubmittedCommand = new SubmittedCommand(command, tile);
            submittedCommands[latestInitiative] = newSubmittedCommand;
            visualizedOrder.submitCommand(newSubmittedCommand);
            orderChangedEvent.Raise();
        } else {
            Debug.LogWarning("Attempted to submit a command with no free next initiative");
        }
    }

    // ========================= //
    // ======== HELPERS ======== //
    // ========================= //

    // Gets the earliest free initiative that is AFTER the latest submitted command
    private int getNextFreeInitiative() {
        int nextFreeInitiative = -1;

        for(int i = 0; i < GlobalDefines.INITIATIVES; i++) {
            if (unitCard.initiatives[i]) {
                if (nextFreeInitiative == -1) {
                    if (submittedCommands[i] == null) {
                        nextFreeInitiative = i;
                    } else {
                        nextFreeInitiative = -1;
                    }
                }
            }
        }

        return nextFreeInitiative;
    }
}
