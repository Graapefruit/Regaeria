using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    private static readonly Color DEFAULT_COLOUR = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    private static readonly Color HIGHLIGHTED_COLOUR = new Color(0.9f, 0.9f, 0.9f, 1.0f);
    private static readonly Color SELECTED_COLOUR = new Color(0.5f, 0.5f, 0.5f, 1.0f);
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
    public Unit Unit {
        get { return unit; }
        set { 
            unit = value; 
            if (unit != null) {
                unit.transform.position = transform.position;
            }
        }
    }
    private bool highlighted;
    private bool selected;
    private Unit unit;
}
