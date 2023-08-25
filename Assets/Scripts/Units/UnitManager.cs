using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour {
    public List<Unit> units;
    
    void Awake() {
        units = new List<Unit>();
    }
}
