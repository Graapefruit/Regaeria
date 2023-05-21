using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardInputHandler : MonoBehaviour
{
    private Board board;
    public Vector3Reference projectedMousePosition;
    private OrderHandler orderHandler;

    void Awake() {
        board = transform.GetComponent<Board>();
        orderHandler = transform.GetComponent<OrderHandler>();
    }

    void Update() {
        setTileAsHovered();
    }

    public void setTileAsSelected() {
        if (projectedMousePosition.get() != null) {
            Tile tile = board.getRespectiveTile(projectedMousePosition.get().Value);
            board.CurrentlySelected = tile;
        }
    }

    public void doMove() {
        if (projectedMousePosition.get() != null) {
            Tile currentlySelected = board.CurrentlySelected;
            Tile currentlyHovered = board.CurrentlyHovered;
            if (currentlySelected != null && currentlyHovered != null && currentlySelected.unit != null) {
                orderHandler.createOrder(currentlySelected, currentlyHovered);
            }
        }
    }

    private void setTileAsHovered() {
        if (projectedMousePosition.get() != null) {
            Tile tile = board.getRespectiveTile(projectedMousePosition.get().Value);
            board.CurrentlyHovered = tile;
        }
    }
}
