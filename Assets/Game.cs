using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    new public Camera camera;
    public GameObject tilePrefab;
    private Board board;
    void Start() {
        board = new Board(tilePrefab);
    }

    // Update is called once per frame
    void Update() {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            if (Input.GetMouseButton(0)) {
                board.setTileAsSelected(hit.point);
            } else if (Input.GetMouseButton(1)) {
                board.doMove(hit.point);
            } else {
                board.setTileAsHovered(hit.point);
            }
        }
    }
}
