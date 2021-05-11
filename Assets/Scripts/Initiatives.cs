using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Initiatives {
    public bool vanguard;
    public bool early;
    public bool middle;
    public bool secondMiddle;
    public bool late;
    public bool final;

    public int getTotalMoves() {
        return (vanguard ? 1 : 0) + 
                (early ? 1 : 0) + 
                (middle ? 1 : 0) + 
                (secondMiddle ? 1 : 0) + 
                (late ? 1 : 0) + 
                (final ? 1 : 0);
    }

    public bool hasInitiativeAtIndex(int index) {
        return (index == 0 && vanguard) ||
                (index == 1 && early) ||
                (index == 2 && middle) ||
                (index == 3 && secondMiddle) ||
                (index == 4 && late) ||
                (index == 5 && final);
    }
}
