using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitBaseStats", menuName = "ScriptableObjects/UnitBaseStats")]
public class UnitBaseStats : ScriptableObject {
    public string unitName;
    public Initiatives initiatives;
    public int baseHp;
    public int baseSpeed;

    void Awake() {
        this.baseSpeed = initiatives.getTotalMoves();
    }
}
