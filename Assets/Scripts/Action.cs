using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action {
    public Unit unit;
    public Tile dest;
    public Order order;

    public Action(Unit unit, Tile dest, Order order) {
        this.unit = unit;
        this.dest = dest;
        this.order = order;
    }

    public ActionRecord doAction() {
        unit.Tile = dest;
        order.popAction();
        return new ActionRecord(unit, dest);
    }
}
