using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardInputHandler : MonoBehaviour
{
    private Board board;
    private OrderHandler orderHandler;
    void Awake() {
        board = transform.GetComponent<Board>();
        orderHandler = transform.GetComponent<OrderHandler>();
    }
    public void setTileAsHovered(Vector3 point) {
        Tile tile = board.getRespectiveTile(point);
        board.CurrentlyHovered = tile;
    }

    public void setTileAsSelected(Vector3 point) {
        Tile tile = board.getRespectiveTile(point);
        board.CurrentlySelected = tile;
    }

    public void doMove(Vector3 point) {
        Tile currentlySelected = board.CurrentlySelected;
        Tile currentlyHovered = board.CurrentlyHovered;
        if (currentlySelected != null && currentlyHovered != null && currentlySelected.unit != null) {
            orderHandler.createOrder(currentlySelected, currentlyHovered);
        }
    }
}
