using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitBaseStats", menuName = "ScriptableObjects/UnitBaseStats")]
public class UnitBaseStats : ScriptableObject {
    public string unitName;
    public int baseSpeed;
    public int baseHp;
}
