using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    public void setAsHighlighted() {
        transform.GetComponent<SpriteRenderer>().color = new Color(0.9f, 0.9f, 0.9f, 1.0f);
    }
    public void removeHighlightedStatus() {
        transform.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
}
