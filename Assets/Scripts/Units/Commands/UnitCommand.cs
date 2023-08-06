using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UnitCommand", menuName = "ScriptableObjects/UnitCommand")]
public class UnitCommand : ScriptableObject {
    public Sprite uiImage;
    public int repeatability;
    public bool requiresBoardInput;
}
