using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardInputHandler : MonoBehaviour
{
    public Vector3Reference projectedMousePosition;
    public UnitReference selectedUnit;
    public BoolReference isMouseOverBlockingUiElement;
    private Board board;

    void Awake() {
        board = transform.GetComponent<Board>();
    }

    public void setTileAsSelected() {
        if (projectedMousePosition.get() != null && !isMouseOverBlockingUiElement.get()) {
            board.CurrentlySelected = board.getRespectiveTile(projectedMousePosition.get().Value);
        }
    }

    public void setTileAsHovered() {
        if (projectedMousePosition.get() != null && !isMouseOverBlockingUiElement.get()) {
            board.CurrentlyHovered = board.getRespectiveTile(projectedMousePosition.get().Value);
        } else {
            board.CurrentlyHovered = null;
        }
    }

    public void doMove() {
        if (projectedMousePosition.get() != null) {
            Tile currentlySelected = board.CurrentlySelected;
            Tile currentlyHovered = board.CurrentlyHovered;
            if (currentlySelected != null && currentlyHovered != null && currentlySelected.unit != null) {
                //orderHandler.createOrder(currentlySelected, currentlyHovered);
            }
        }
    }
}
