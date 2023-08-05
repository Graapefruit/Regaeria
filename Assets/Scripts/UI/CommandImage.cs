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
    public UnitCommand command;
    public UnitReference selectedUnitReference;

    private bool isSelected;

    public void initialize(UnitCommand unitCommand, Vector2 newPosition) {
        this.rectTransform.anchoredPosition = newPosition;
        this.image.sprite = unitCommand.uiImage;
        this.imageGraphic = this.GetComponent<Graphic>();
        this.imageGraphic.color = unselectedColour;
        this.command = unitCommand;

        this.isSelected = this.selectedUnitReference.get().selectedCommand == command;
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
        this.selectedUnitReference.get().selectedCommand = command;
        this.imageGraphic.color = selectedColour;
    }

    private void deselectCommand() {
        this.selectedUnitReference.get().selectedCommand = null;
        this.imageGraphic.color = unselectedColour;
    }
}
