using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour {
    // TODO: Float Reference
    public float board_scale = 0.6f;
    public GameObject arrowStartPrefab;
    public GameObject arrowStraightPrefab;
    public GameObject arrowBendWidePrefab;
    public GameObject arrowBendTightPrefab;
    public GameObject arrowEndPrefab;
    private Board board;
    private Unit unit;
    private List<GameObject> arrowSegments;
    private List<Tile> tiles;

    public void assign(Board board, Unit unit, List<Tile> tiles) {
        this.board = board;
        this.unit = unit;
        this.tiles = tiles;
        this.arrowSegments = new List<GameObject>();
        createArrows(tiles);
    }

    public Action getAction() {
        if (tiles.Count == 1) {
            return null;
        }
        return new Action(unit, tiles[1], this);
    }

    public Tile getCurrentTile() {
        return tiles[0];
    }

    public void popAction() {
        tiles.RemoveAt(0);
    }

    private void createArrows(List<Tile> tiles) {
        for (int i = 0; i < tiles.Count; i++) {
            Vector3 pos = tiles[i].transform.position;
            pos.y += 0.5f;
            GameObject prefab;
            Quaternion rot;

            if (i == tiles.Count - 1) {
                int direction = AdjacencyHelper.getConnection(tiles[i].index, tiles[i-1].index);
                prefab = arrowEndPrefab;
                rot = Quaternion.Euler(90.0f, (direction - 3) * 60.0f, 0.0f);
            } else if (i == 0) {
                int direction = AdjacencyHelper.getConnection(tiles[i].index, tiles[i+1].index);
                prefab = arrowStartPrefab;
                rot = Quaternion.Euler(90.0f, direction * 60.0f, 0.0f);
            } else {
                int directionPrevious = AdjacencyHelper.getConnection(tiles[i].index, tiles[i-1].index);
                int directionNext = AdjacencyHelper.getConnection(tiles[i].index, tiles[i+1].index);
                prefab = getPrefabMiddle(directionPrevious, directionNext, out rot);
            }
            GameObject arrowSegment = Instantiate(prefab, pos, rot);
            arrowSegment.transform.localScale = new Vector3(board_scale, board_scale, board_scale);
            arrowSegment.transform.SetParent(transform, true);
            arrowSegments.Add(arrowSegment);
        }
    }

    private GameObject getPrefabMiddle(int directionPrevious, int directionNext, out Quaternion rot) {
        GameObject prefab;
        float yRotation = (directionPrevious - 3) * 60.0f;
        int directionDifference = directionPrevious - directionNext;
        switch (Mathf.Abs(directionDifference)) {
            case 0:
                prefab = arrowStartPrefab;
                break;
            case 1:
                prefab = arrowBendTightPrefab;
                break;
            case 2:
                prefab = arrowBendWidePrefab;
                break;
            case 3:
                prefab = arrowStraightPrefab;
                break;
            case 4:
                prefab = arrowBendWidePrefab;
                break;
            case 5:
                prefab = arrowStraightPrefab;
                break;
            default:
                prefab = null;
                break;
        }
        
        if (prefab == arrowBendTightPrefab) {
            if (directionDifference == -1 || directionDifference == 5) {
                yRotation += 60.0f;
            }
        } else if (arrowBendWidePrefab) {
            if (directionDifference == -2 || directionDifference == 4) {
                yRotation += 120.0f;
            }
        }
        rot = Quaternion.Euler(90.0f, yRotation, 0.0f);
        return prefab;
    }
}
