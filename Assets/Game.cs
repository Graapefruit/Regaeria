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
            board.setTileAsHovered(hit.point);
        }
    }
}
