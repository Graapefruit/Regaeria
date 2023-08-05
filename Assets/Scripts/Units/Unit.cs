using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    public UnitCard unitCard;
    public UnitStatus unitStatus;
    public UnitCommand queuedCommands;
    public UnitCommand selectedCommand;
    
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

    public void giveNewCommand() {
        
    }
}
