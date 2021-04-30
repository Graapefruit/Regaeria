using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitInfo", menuName = "ScriptableObjects/UnitInfo")]
public class UnitInfo : ScriptableObject {
    new public string name;
    public GameObject prefab;
    public int speed;
}
