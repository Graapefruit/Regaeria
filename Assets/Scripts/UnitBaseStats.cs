using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitInfo", menuName = "ScriptableObjects/UnitInfo")]
public class UnitBaseStats : ScriptableObject {
    public string unitName;
    public int baseSpeed;
    public int baseHp;
}
