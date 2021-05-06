using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    private static readonly Color DEFAULT_COLOUR = new Color(0.77f, 1.0f, 1.0f, 1.0f);
    private static readonly Color HIGHLIGHTED_COLOUR = new Color(0.6f, 0.85f, 0.85f, 1.0f);
    private static readonly Color SELECTED_COLOUR = new Color(0.3f, 0.5f, 0.5f, 1.0f);
    public Unit unit;
    public Pair<int, int> index;
    public bool Highlighted {
        get { return highlighted; }
        set { 
            highlighted = value;
            if (!selected) {
                transform.GetComponent<SpriteRenderer>().color = (highlighted ? HIGHLIGHTED_COLOUR : DEFAULT_COLOUR);
            }
        }
    }
    public bool Selected {
        get { return selected; }
        set {
            selected = value;
            transform.GetComponent<SpriteRenderer>().color = (selected ? SELECTED_COLOUR : (highlighted ? HIGHLIGHTED_COLOUR : DEFAULT_COLOUR));
        }
    }
    private bool highlighted;
    private bool selected;

    void Update() {
        if (unit != null) {
            unit.transform.position = transform.position;
        }
    }
}
