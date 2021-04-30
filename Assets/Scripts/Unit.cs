using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    public UnitInfo UnitInfo {
        get { return unitInfo; }
        set { 
            if (unitInfo == null) {
                unitInfo = value;
                Instantiate(unitInfo.prefab, Vector3.zero, Quaternion.identity).transform.SetParent(transform, false);
            } else {
                Debug.Log("Warning: Attempting to set unit info when it already exists!");
            }
        }
    }
    private UnitInfo unitInfo;

    void Awake() {

    }
}
