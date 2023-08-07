using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AdjacencyHelper {
    public static GridDirection getConnection(Pair<int, int> source, Pair<int, int> dest) {
        if (source.x == dest.x && source.z - 1 == dest.z) {
            return GridDirection.UP;
        } else if (source.x + 1 == dest.x && source.z - ((source.x + 1) % 2) == dest.z) {
            return GridDirection.UPRIGHT;
        } else if (source.x + 1 == dest.x && source.z + (source.x % 2) == dest.z) {
            return GridDirection.DOWNRIGHT;
        } else if (source.x == dest.x && source.z + 1 == dest.z) {
            return GridDirection.DOWN;
        } else if (source.x - 1 == dest.x && source.z + (source.x % 2) == dest.z) {
            return GridDirection.DOWNLEFT;
        } else if (source.x - 1 == dest.x && source.z - ((source.x + 1) % 2) == dest.z) {
            return GridDirection.UPLEFT;
        } else {
            Debug.LogError("AdjacencyHelper.getConnection returned an error!");
            return GridDirection.UP;
        }
    }

    public enum GridDirection : ushort {
        UP = 0,
        UPRIGHT = 1,
        DOWNRIGHT = 2,
        DOWN = 3,
        DOWNLEFT = 4,
        UPLEFT = 5,
    }
}
