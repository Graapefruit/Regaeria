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
        List<Tile> path = board.getPath(source, destination);
        Order order = Instantiate(orderPrefab, source.transform.position, Quaternion.identity).GetComponent<Order>();
        if (orders.ContainsKey(unit)) {
            Destroy(orders[unit].gameObject);
        }
        orders[unit] = order;
        order.assign(unit, path);
    }
}
