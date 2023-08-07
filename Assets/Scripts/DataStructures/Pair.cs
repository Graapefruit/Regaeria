using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pair<T, G> {
    public T x;
    public G z;

    public Pair(T x, G z) {
        this.x = x; 
        this.z = z;
    }

    public override string ToString() {
        return "(" + x + ", " + z + ")";
    }
}
