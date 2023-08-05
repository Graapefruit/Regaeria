using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICommandLister : MonoBehaviour
{
    public UnitReference selectedUnit;
    public GameObject commandIconPrefab;
    public List<GameObject> commandIcons;
    private float COMMAND_ICON_DIMENSIONS;
    private const float COMMAND_ICON_PADDING = 20.0f;

    void Awake() {
        this.COMMAND_ICON_DIMENSIONS = this.commandIconPrefab.GetComponent<RectTransform>().rect.width;
        this.commandIcons = new List<GameObject>();
    }

    public void onNewUnitSelected() {
        purgeCommandIcons();
        generateNewCommandIcons();
    }

    private void purgeCommandIcons() {
        foreach(GameObject commandIcon in this.commandIcons) {
            Destroy(commandIcon);
        }
        this.commandIcons = new List<GameObject>();
    }

    private void generateNewCommandIcons() {
        if (selectedUnit.hasValue()) {
            float xBaseOffset = (COMMAND_ICON_PADDING / 2) + (COMMAND_ICON_DIMENSIONS / 2);
            Vector2 newPosition = new Vector2(xBaseOffset, 0.0f);
            foreach(UnitCommand unitCommand in this.selectedUnit.get().unitCard.unitCommands) {
                GameObject newCommand = Instantiate(commandIconPrefab, Vector3.zero, Quaternion.identity);
                newCommand.transform.SetParent(this.transform, false);

                newCommand.GetComponent<RectTransform>().anchoredPosition = newPosition;
                newCommand.GetComponent<Image>().sprite = unitCommand.uiImage;

                commandIcons.Add(newCommand);
                newPosition.y -= COMMAND_ICON_DIMENSIONS + COMMAND_ICON_PADDING;
            }
        }
    }
}
