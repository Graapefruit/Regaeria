using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    new public Camera camera;
    public GameObject tilePrefab;
    private const int BOARD_SIZE = 16;
    private const float TILE_SCALE = 0.6f;
    private const float ROOT_THREE = 1.73205080757f;
    private const float X_START = -(BOARD_SIZE - 1) * ROOT_THREE * TILE_SCALE / 2;
    private const float Z_START = ((BOARD_SIZE - 1) * TILE_SCALE);
    // The lazy box is used to help with calculations: 
    // it is a rectangle which encapsulates part of the hexagon, starting from the very left, to the start of the teeth on the right
    private const float HEXAGON_SIDE_LENGTH = 2 * TILE_SCALE / ROOT_THREE;
    private const float HEXAGON_TOOTH_LENGTH = TILE_SCALE / ROOT_THREE;

    private const float LAZY_BOX_LENGTH = HEXAGON_SIDE_LENGTH + HEXAGON_TOOTH_LENGTH;
    private const float LAZY_BOX_HEIGHT = 2 * TILE_SCALE;
    private const float GRID_LEFT_EDGE = X_START - ((HEXAGON_SIDE_LENGTH / 2) + HEXAGON_TOOTH_LENGTH);
    private const float GRID_TOP_EDGE = Z_START + TILE_SCALE;
    private Tile[,] board;
    // Start is called before the first frame update
    void Start() {
        board = new Tile[BOARD_SIZE, BOARD_SIZE];
        initializeBoard();
    }

    // Update is called once per frame
    void Update() {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            getRespectiveTile(hit.point);
        }
    }

    private GameObject getRespectiveTile(Vector3 point) {
        if (pointInBounds(point)) {
            int xIndex = Mathf.FloorToInt((point.x - GRID_LEFT_EDGE) / LAZY_BOX_LENGTH);
            int zIndex = Mathf.FloorToInt((GRID_TOP_EDGE - point.z + ((xIndex % 2) * -TILE_SCALE)) / LAZY_BOX_HEIGHT);
            // TODO: Edge cases (literally) and teeth
            Debug.LogFormat("{0}, {1}", xIndex, zIndex);
            Pair<int, int> newIndices = updateIndexFromLazyBoxToHexagon(point, xIndex, zIndex);
            xIndex = newIndices.x;
            zIndex = newIndices.z;


            if (indexInBounds(xIndex, zIndex)) {
                board[xIndex, zIndex].setAsHighlighted();
            }
        } else {
            return null;
        }
        return null;
    }

    private Pair<int, int> updateIndexFromLazyBoxToHexagon(Vector3 point, int xIndex, int zIndex) {
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
        return new Pair<int, int>(xIndex, zIndex);
    }

    private Pair<int, int> getUpLeft(int xIndex, int zIndex) {
        return new Pair<int, int>(xIndex - 1, zIndex - ((xIndex + 1) % 2));
    }

    private Pair<int, int> getDownLeft(int xIndex, int zIndex) {
        return new Pair<int, int>(xIndex - 1, zIndex + (xIndex % 2));
    }
 
    private bool pointInBounds(Vector3 point) {
        bool belowUpper = point.z < GRID_TOP_EDGE;
        bool aboveLower = point.z > -GRID_TOP_EDGE;
        bool rightOfLeft = point.x > GRID_LEFT_EDGE;
        bool leftOfRight = point.x < -GRID_LEFT_EDGE;
        return belowUpper && aboveLower && rightOfLeft && leftOfRight;
    }

    private bool indexInBounds(int x, int z) {
        return x > 0 && x < BOARD_SIZE && z > 0 && z < BOARD_SIZE;
    }

    private void initializeBoard() {
        for (int x = 0; x < BOARD_SIZE; x++) {
            for (int z = 0; z < BOARD_SIZE; z++) {
                float xStart = X_START + TILE_SCALE * ROOT_THREE * x;
                float zStart = Z_START - TILE_SCALE * (2.0f * z + (x % 2));
                board[x, z] = Instantiate(tilePrefab, new Vector3(xStart, 0.001f, zStart), Quaternion.Euler(90.0f, 0.0f, 0.0f)).GetComponent<Tile>();
                board[x, z].gameObject.transform.localScale = new Vector3(TILE_SCALE, TILE_SCALE, TILE_SCALE);
            }
        }
    }
}
