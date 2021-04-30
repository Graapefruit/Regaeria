using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInstantiator : MonoBehaviour {
    public GameObject unitPrefab;
    public UnitInfo morozilInfo;

    private static UnitInstantiator me;
    void Awake() {
        if (me != null) {
            Debug.Log("WARNING: Copy of UnitInstantiator already detected. Skipping");
        } else {
            me = this;
        }
    }

    public static Unit createNewMorozil() {
        Unit newUnit = Instantiate(me.unitPrefab, Vector3.zero, Quaternion.identity).GetComponent<Unit>();
        newUnit.UnitInfo = me.morozilInfo;
        return newUnit;
    }
}
