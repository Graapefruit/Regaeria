using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderHandler : MonoBehaviour {
    public GameObject orderPrefab;
    private Dictionary<Unit, Order> orders;
    private Board board;

    void Awake() {
        board = transform.GetComponent<Board>();
        orders = new Dictionary<Unit, Order>();
    }

    public void createOrder(Tile source, Tile destination) {
        if (source == null || destination == null || source == destination) {
            return;
        }
        Unit unit = source.unit;
        if (orders.ContainsKey(unit)) {
            Destroy(orders[unit].gameObject);
            orders.Remove(unit);
        }
        List<Tile> path = board.getPath(source, destination, unit.baseStats.baseSpeed);
        if (path != null) {
            Order order = Instantiate(orderPrefab, source.transform.position, Quaternion.identity).GetComponent<Order>();
            order.assign(board, unit, path);
            orders[unit] = order;
        }
    }

    public void doTurn() {
        for (int initiative = 0; initiative < 6; initiative++) {
            ActionList actionList = new ActionList();
            foreach(KeyValuePair<Unit, Order> unitOrder in orders) {
                if (unitOrder.Key.baseStats.initiatives.hasInitiativeAtIndex(initiative)) {
                    Action newAction = unitOrder.Value.getAction();
                    if (newAction != null) {
                        actionList.addAction(newAction);
                    }
                }
            }
            actionList.doActions();
        }
        foreach(KeyValuePair<Unit, Order> unitOrder in orders) {
            Destroy(orders[unitOrder.Key].gameObject);
        }
        orders = new Dictionary<Unit, Order>();
    }
}
