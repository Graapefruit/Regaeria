using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerUI : MonoBehaviour
{
    public UnitReference selectedUnit;
    private Text unitName;
    private Text unitHealth;

    void Awake() {
        this.unitName = this.transform.Find("UnitName").GetComponent<Text>();
        this.unitHealth = this.transform.Find("UnitHealth").GetComponent<Text>();
    }

    void Update() {
        updateUnitCard();
    }

    private void updateUnitCard() {
        if (selectedUnit.reference == null) {
            unitName.text = "No Unit Selected";
            unitHealth.gameObject.SetActive(false);
        } else {
            unitName.text = selectedUnit.reference.unitCard.unitName;
            unitHealth.gameObject.SetActive(true);
            unitHealth.text = "Health: " + selectedUnit.reference.unitStatus.currentHp;
        }
    }
}
