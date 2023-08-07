using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizedOrder : MonoBehaviour {
    public GameObject arrowStartPrefab;
    public GameObject arrowStraightPrefab;
    public GameObject arrowBendWideLeftPrefab;
    public GameObject arrowBendWideRightPrefab;
    public GameObject arrowBendTightLeftPrefab;
    public GameObject arrowBendTightRightPrefab;
    public GameObject arrowEndPrefab;
    public Unit unit;

    private List<Pair<GameObject, Tile>> segments;

    void Awake() {
        segments = new List<Pair<GameObject, Tile>>();
    }

    public void submitCommand(SubmittedCommand submittedCommand) {
        if (segments.Count == 0) {
            createOrderVisual(arrowStartPrefab, 
                unit.Tile.transform.position, 
                Quaternion.LookRotation(Vector3.up, submittedCommand.tile.transform.position - unit.Tile.transform.position),
                unit.Tile);
        } else {
            Pair<GameObject, Tile> oldSegment = segments[segments.Count-1];
            GameObject oldGameObject = oldSegment.x;
            Tile oldTile = oldSegment.z;
            segments.RemoveAt(segments.Count-1);

            createOrderVisual(getProperPrefab(segments[segments.Count-1].z, oldTile, submittedCommand.tile), 
                oldGameObject.transform.position, 
                oldGameObject.transform.rotation,
                oldTile);
            Destroy(oldGameObject);
        }

        createOrderVisual(arrowEndPrefab, 
            submittedCommand.tile.transform.position,
            Quaternion.LookRotation(Vector3.up, submittedCommand.tile.transform.position - segments[segments.Count-1].x.transform.position),
            submittedCommand.tile);
    }

    private GameObject getProperPrefab(Tile prevTile, Tile sourceTile, Tile destTile) {
        int incomingDirection = (int) AdjacencyHelper.getConnection(prevTile.index, sourceTile.index);
        int outgoingDirection = (int) AdjacencyHelper.getConnection(sourceTile.index, destTile.index);
        Debug.Log(incomingDirection);
        Debug.Log(outgoingDirection);

        int directionDifference = incomingDirection - outgoingDirection;
        directionDifference += directionDifference < 0 ? 6 : 0;
        switch (directionDifference) {
            case 0:
                return arrowStraightPrefab;
            case 1:
                return arrowBendWideRightPrefab;
            case 2:
                return arrowBendTightRightPrefab;
            case 3:
                // TODO: This one is a lil fucky, maybe make a new one for it?
                return arrowStartPrefab;
            case 4:
                return arrowBendTightLeftPrefab;
            case 5:
                return arrowBendWideLeftPrefab;
            default:
                return null;
        }
    }

    private void createOrderVisual(GameObject arrowSegmentPrefab, Vector3 location, Quaternion rotation, Tile tile) {
        GameObject instantiatedArrowSegment = Instantiate(arrowSegmentPrefab, location, rotation);
        segments.Add(new Pair<GameObject, Tile>(instantiatedArrowSegment, tile));
    }
}
