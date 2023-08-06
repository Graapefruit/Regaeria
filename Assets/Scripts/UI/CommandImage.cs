using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandImage : MonoBehaviour {
    public readonly Color unselectedColour = new Color(1.0f, 1.0f, 1.0f, 0.7f); 
    public readonly Color selectedColour = new Color(1.0f, 1.0f, 1.0f, 1.0f); 

    public RectTransform rectTransform;
    public Image image;
    public Graphic imageGraphic;
    public CommandReference selectedCommandReference;

    private UnitCommand currentCommand;
    private bool isSelected;

    public void initialize(UnitCommand unitCommand, Vector2 newPosition) {
        this.rectTransform.anchoredPosition = newPosition;
        this.image.sprite = unitCommand.uiImage;
        this.imageGraphic = this.GetComponent<Graphic>();
        this.imageGraphic.color = unselectedColour;
        this.currentCommand = unitCommand;

        this.isSelected = selectedCommandReference.get() == currentCommand;
        toggleSelect();
    }

    public void onClick() {
        this.isSelected = !this.isSelected;
        toggleSelect();
    }

    private void toggleSelect() {
        if (this.isSelected) {
            selectCommand();
        } else {
            deselectCommand();
        }
    }

    private void selectCommand() {
        selectedCommandReference.set(currentCommand);
        this.imageGraphic.color = selectedColour;
    }

    private void deselectCommand() {
        selectedCommandReference.set(null);
        this.imageGraphic.color = unselectedColour;
    }
}
