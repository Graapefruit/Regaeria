using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitiativePanel : MonoBehaviour
{
    private readonly Color NO_INITIATIVE_COLOUR =  new Color(0.35f, 0.35f, 0.35f);
    private readonly Color UNCHOSEN_INITIATIVE_COLOUR =  new Color(0.69f, 0.00f, 0.00f);

    public Text[] initiativeNumbers;
    public UnitReference selectedUnitReference;

    public void onNewUnitSelected() {
        toggleInitiativeNumbers(selectedUnitReference.hasValue());
        if (selectedUnitReference.hasValue()) {
            setTextColours(selectedUnitReference.get().unitCard.initiatives);
        }
    }

    private void toggleInitiativeNumbers(bool toggle) {
        foreach(Text initiativeNumber in initiativeNumbers) {
            initiativeNumber.enabled = toggle;
        }
    }

    private void setTextColours(bool[] unitInitiatives) {
        for (int i = 0; i < GlobalDefines.INITIATIVES; i++) {
            initiativeNumbers[i].color = (unitInitiatives[i] ? UNCHOSEN_INITIATIVE_COLOUR : NO_INITIATIVE_COLOUR);
        }
    }
}
