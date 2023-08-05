using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UnitCommand", menuName = "ScriptableObjects/UnitCommand")]
public class UnitCommand : ScriptableObject
{
    // Ensure there are 6 entries here, even if most are null
    public Sprite uiImage;
    public bool requiresBoardInput;
}
