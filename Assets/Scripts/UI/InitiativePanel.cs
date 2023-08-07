using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitiativePanel : MonoBehaviour
{
    private readonly Color NO_INITIATIVE_COLOUR =  new Color(0.35f, 0.35f, 0.35f);
    private readonly Color UNSUBMITTED_INITIATIVE_COLOUR =  new Color(0.69f, 0.00f, 0.00f);
    private readonly Color SUBMITTED_INITIATIVE_COLOUR =  new Color(0.16f, 0.67f, 0.07f);

    public Text[] initiativeNumbers;
    public UnitReference selectedUnitReference;

    public void onNewUnitSelected() {
        toggleInitiativeNumbers(selectedUnitReference.hasValue());
        if (selectedUnitReference.hasValue()) {
            setTextColours(selectedUnitReference.get());
        }
    }

    public void onOrderUpdated() {
        setTextColours(selectedUnitReference.get());
    }

    private void toggleInitiativeNumbers(bool toggle) {
        foreach(Text initiativeNumber in initiativeNumbers) {
            initiativeNumber.enabled = toggle;
        }
    }

    private void setTextColours(Unit unit) {
        for (int i = 0; i < GlobalDefines.INITIATIVES; i++) {
            initiativeNumbers[i].color = (unit.unitCard.initiatives[i] ? 
                (unit.submittedCommands[i] != null ? SUBMITTED_INITIATIVE_COLOUR : UNSUBMITTED_INITIATIVE_COLOUR) : 
                NO_INITIATIVE_COLOUR);
        }
    }
}
