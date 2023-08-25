using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnText : MonoBehaviour {
    public IntReference turnCount;
    public Text text;

    void Start() {
        updateText();
    }

    public void updateText() {
        text.text = string.Format("Turn {0}", turnCount.get());
    }
}
