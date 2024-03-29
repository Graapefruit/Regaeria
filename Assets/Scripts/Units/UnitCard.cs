using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitCard", menuName = "ScriptableObjects/UnitCard")]
public class UnitCard : ScriptableObject
{
    public string unitName;
    public int baseHp;
    public bool[] initiatives;
    public UnitCommand[] unitCommands;
}
