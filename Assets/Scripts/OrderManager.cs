using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour {
    public List<Unit> units;

    public void addUnit(Unit unit) {
        this.units.Add(unit);
        unit.orderManager = this;
    }
}
