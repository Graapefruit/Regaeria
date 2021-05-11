using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action {
    public Unit unit;
    public Tile source;
    public Tile dest;
    public Order order;

    public Action(Unit unit, Tile source, Tile dest, Order order) {
        this.unit = unit;
        this.source = source;
        this.dest = dest;
        this.order = order;
    }

    public void doAction() {
        source.unit = null;
        dest.unit = unit;
        order.popAction();
    }
}
