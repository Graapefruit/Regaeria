using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitStatus", menuName = "ScriptableObjects/UnitStatus")]
public class UnitStatus : ScriptableObject
{
    public int currentHp;

    public void initializeStatus(UnitCard unitCard) {
        this.currentHp = unitCard.baseHp;
    }
}
