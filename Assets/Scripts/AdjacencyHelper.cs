using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AdjacencyHelper {

    // 0 = Up
    // 1 = UpRight
    // 2 = Down Right
    // 3 = Down
    // 4 = DownLeft
    // 5 = UpLeft
    // -42 = ??? Error

    public static int getConnection(Pair<int, int> self, Pair<int, int> toFace) {
        if (self.x == toFace.x && self.z - 1 == toFace.z) {
            return 0;
        } else if (self.x + 1 == toFace.x && self.z - ((self.x + 1) % 2) == toFace.z) {
            return 1;
        } else if (self.x + 1 == toFace.x && self.z + (self.x % 2) == toFace.z) {
            return 2;
        } else if (self.x == toFace.x && self.z + 1 == toFace.z) {
            return 3;
        } else if (self.x - 1 == toFace.x && self.z + (self.x % 2) == toFace.z) {
            return 4;
        } else if (self.x - 1 == toFace.x && self.z - ((self.x + 1) % 2) == toFace.z) {
            return 5;
        } else {
            return -42;
        }
    }
}
