using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    public UnitBaseStats baseStats;
    public UnitStatBlock currentStats;
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
        currentStats = ScriptableObject.CreateInstance("UnitStatBlock") as UnitStatBlock;
        currentStats.initializeStats(baseStats);
    }

    void OnValidate() {
        if (editorTile != null) {
            Tile = editorTile;
        }
    }
}
