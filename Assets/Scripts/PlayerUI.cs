using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerUI : MonoBehaviour
{
    public StatBlockReference selectedUnit;
    private Text unitName;
    private Text unitHealth;

    void Awake() {
        this.unitName = this.transform.Find("UnitName").GetComponent<Text>();
        this.unitHealth = this.transform.Find("UnitHealth").GetComponent<Text>();
        Debug.Log(unitName);
    }

    // Update is called once per frame
    void Update() {
        updateUnitCard();
    }

    private void updateUnitCard() {
        if (selectedUnit.statBlock == null) {
            unitName.text = "No Unit Selected";
            unitHealth.gameObject.SetActive(false);
        } else {
            unitName.text = selectedUnit.statBlock.baseStats.unitName;
            unitHealth.gameObject.SetActive(true);
            unitHealth.text = "Health: " + selectedUnit.statBlock.currentHp;
        }
    }
}
