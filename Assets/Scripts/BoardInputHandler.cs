using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardInputHandler : MonoBehaviour
{
    public Vector3Reference projectedMousePosition;
    public UnitReference selectedUnit;
    public BoolReference isMouseOverBlockingUiElement;
    public CommandReference selectedCommand;
    private Board board;

    void Awake() {
        board = transform.GetComponent<Board>();
    }

    public void setTileAsSelected() {
        if (projectedMousePosition.get() != null && !isMouseOverBlockingUiElement.get()) {
            board.CurrentlySelected = board.getRespectiveTile(projectedMousePosition.get().Value);
            selectedCommand.set(null);
        }
    }

    public void setTileAsHovered() {
        if (projectedMousePosition.get() != null && !isMouseOverBlockingUiElement.get()) {
            board.CurrentlyHovered = board.getRespectiveTile(projectedMousePosition.get().Value);
        } else {
            board.CurrentlyHovered = null;
        }
    }

    public void onIssueCommand() {
        if (selectedUnit.hasValue() && selectedCommand.hasValue()) {
            Unit unit = selectedUnit.get();
            UnitCommand command = selectedCommand.get();

            List<Tile> path = board.getPath(unit.getProjectedLocationAfterCommands(), 
                board.getRespectiveTile(projectedMousePosition.get()), 
                unit.getRemainingUses(command));

            if (path != null) {
                path.RemoveAt(0);
                foreach(Tile segment in path) {
                    unit.submitCommand(command, segment);
                }
            }
        }

    }
}
