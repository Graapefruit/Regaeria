using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
    // The lazy box is used to help with calculations: 
    // it is a rectangle which encapsulates part of the hexagon, starting from the very left, to the start of the teeth on the right
    // Note: the hexagonal grid is stored in a 2D array of type odd-q: https://www.redblobgames.com/grids/hexagons/
    public UnitReference selectedUnit;
    public GameObject tilePrefab;
    private const int BOARD_SIZE = 16;
    private const float TILE_SCALE = 0.6f;
    private const float ROOT_THREE = 1.73205080757f;
    private const float X_START = -(BOARD_SIZE - 1) * ROOT_THREE * TILE_SCALE / 2;
    private const float Z_START = ((BOARD_SIZE - 1) * TILE_SCALE);
    private const float HEXAGON_SIDE_LENGTH = 2 * TILE_SCALE / ROOT_THREE;
    private const float HEXAGON_TOOTH_LENGTH = TILE_SCALE / ROOT_THREE;

    private const float LAZY_BOX_LENGTH = HEXAGON_SIDE_LENGTH + HEXAGON_TOOTH_LENGTH;
    private const float LAZY_BOX_HEIGHT = 2 * TILE_SCALE;
    private const float GRID_LEFT_EDGE = X_START - ((HEXAGON_SIDE_LENGTH / 2) + HEXAGON_TOOTH_LENGTH);
    private const float GRID_TOP_EDGE = Z_START + TILE_SCALE;
    public Tile CurrentlyHovered {
        get { return currentlyHovered; }
        set {
            if (currentlyHovered != null) {
                currentlyHovered.Highlighted = false;
            }
            if (value != null) {
                value.Highlighted = true;
            }
            currentlyHovered = value;
        }
    }
    public Tile CurrentlySelected {
        get { return currentlySelected; }
        set {
            if (currentlySelected != null) {
                currentlySelected.Selected = false;
            }
            if (value != null) {
                value.Selected = true;
                selectedUnit.reference = value.unit;
            } else {
                selectedUnit.reference = null;
            }
            currentlySelected = value;
        }
    }
    private Tile currentlyHovered;
    private Tile currentlySelected;
    private Tile[,] board;
    void Awake() {
        board = new Tile[BOARD_SIZE, BOARD_SIZE];
        initializeBoard(tilePrefab);
    }

    public Tile getRespectiveTile(Vector3 point) {
        int xIndex = Mathf.FloorToInt((point.x - GRID_LEFT_EDGE) / LAZY_BOX_LENGTH);
        int zIndex = Mathf.FloorToInt((GRID_TOP_EDGE - point.z + ((xIndex % 2) * -TILE_SCALE)) / LAZY_BOX_HEIGHT);
        if (tileExists(new Pair<int, int>(xIndex, zIndex))) {
            return updateIndexFromLazyBoxToHexagon(point, xIndex, zIndex);
        } else {
            return null;
        }
    }

    public List<Tile> getPath(Tile source, Tile destination, int maxDepth) {
        if (source == null || destination == null) {
            return null;
        }
        BFSQueue<Tile> queue = new BFSQueue<Tile>();
        queue.add(source, new List<Tile>());
        while(!queue.isEmpty()) {
            List<Tile> path;
            Tile tile = queue.pop(out path);
            if (path.Count-1 > maxDepth) {
                return null;
            } else if (tile == destination) {
                return path;
            }
            List<Tile> neighbours = getNeighbours(tile);
            foreach(Tile neighbour in neighbours) {
                queue.add(neighbour, path);
            }
        }
        return null;
    }

    private List<Tile> getNeighbours(Tile tile) {
        List<Tile> tiles = new List<Tile>();
        int x = tile.index.x;
        int z = tile.index.z;
        Tile up = getUp(x, z);
        Tile upRight = getUpRight(x, z);
        Tile downRight = getDownRight(x, z);
        Tile down = getDown(x, z);
        Tile downLeft = getDownLeft(x, z);
        Tile upLeft = getUpLeft(x, z);
        if (up != null) {
            tiles.Add(up);
        }
        if (upRight != null) {
            tiles.Add(upRight);
        }
        if (downRight != null) {
            tiles.Add(downRight);
        }
        if (down != null) {
            tiles.Add(down);
        }
        if (downLeft != null) {
            tiles.Add(downLeft);
        }
        if (upLeft != null) {
            tiles.Add(upLeft);
        }
        return tiles;
    }

    private Tile updateIndexFromLazyBoxToHexagon(Vector3 point, int xIndex, int zIndex) {
        float midHorizontalLine = Z_START - TILE_SCALE * (2.0f * zIndex + (xIndex % 2));
        float hexagonVeryRight = GRID_LEFT_EDGE + (LAZY_BOX_LENGTH * xIndex);
        float slope = ROOT_THREE * (point.x - hexagonVeryRight);
        if (point.z > midHorizontalLine) {
            if (point.z > midHorizontalLine + slope) {
                return getUpLeft(xIndex, zIndex);
            }
        } else {
            if (point.z < midHorizontalLine - slope) {
                return getDownLeft(xIndex, zIndex);
            }
        }
        return board[xIndex, zIndex];
    }

    private Tile getUp(int xIndex, int zIndex) {
        Pair<int, int> coords = new Pair<int, int>(xIndex, zIndex - 1);
        if (tileExists(coords)) {
            return board[coords.x, coords.z];
        }
        return null;
    }

    private Tile getUpRight(int xIndex, int zIndex) {
        Pair<int, int> coords = new Pair<int, int>(xIndex + 1, zIndex - ((xIndex + 1) % 2));
        if (tileExists(coords)) {
            return board[coords.x, coords.z];
        }
        return null;
    }

    private Tile getDownRight(int xIndex, int zIndex) {
        Pair<int, int> coords = new Pair<int, int>(xIndex + 1, zIndex + (xIndex % 2));
        if (tileExists(coords)) {
            return board[coords.x, coords.z];
        }
        return null;
    }

    private Tile getDown(int xIndex, int zIndex) {
        Pair<int, int> coords = new Pair<int, int>(xIndex, zIndex + 1);
        if (tileExists(coords)) {
            return board[coords.x, coords.z];
        }
        return null;
    }

    private Tile getDownLeft(int xIndex, int zIndex) {
        Pair<int, int> coords = new Pair<int, int>(xIndex - 1, zIndex + (xIndex % 2));
        if (tileExists(coords)) {
            return board[coords.x, coords.z];
        }
        return null;
    }

    private Tile getUpLeft(int xIndex, int zIndex) {
        Pair<int, int> coords = new Pair<int, int>(xIndex - 1, zIndex - ((xIndex + 1) % 2));
        if (tileExists(coords)) {
            return board[coords.x, coords.z];
        }
        return null;
    }

    private bool tileExists(Pair<int, int> p) {
        return p.x >= 0 && p.x < BOARD_SIZE && p.z >= 0 && p.z < BOARD_SIZE && board[p.x, p.z] != null;
    }
 
    private bool pointInBounds(Vector3 point) {
        bool belowUpper = point.z < GRID_TOP_EDGE;
        bool aboveLower = point.z > -GRID_TOP_EDGE;
        bool rightOfLeft = point.x > GRID_LEFT_EDGE;
        bool leftOfRight = point.x < -GRID_LEFT_EDGE;
        return belowUpper && aboveLower && rightOfLeft && leftOfRight;
    }

    private void initializeBoard(GameObject tilePrefab) {
        for (int x = 0; x < BOARD_SIZE; x++) {
            for (int z = 0; z < BOARD_SIZE; z++) {
                float xStart = X_START + TILE_SCALE * ROOT_THREE * x;
                float zStart = Z_START - TILE_SCALE * (2.0f * z + (x % 2));
                Vector3 coords = new Vector3(xStart, 0.001f, zStart);
                board[x, z] = GameObject.Instantiate(tilePrefab, coords, Quaternion.Euler(90.0f, 0.0f, 0.0f)).GetComponent<Tile>();
                board[x, z].index = new Pair<int, int>(x, z);
                board[x, z].gameObject.transform.localScale = new Vector3(TILE_SCALE, TILE_SCALE, TILE_SCALE);
                board[x, z].transform.SetParent(this.transform, false);
            }
        }
    }
}
