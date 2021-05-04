using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    new private Camera camera;
    public Board board;
    void Update() {
        if (camera == null) {
            camera = transform.GetChild(0).GetComponent<Camera>();
        } else if (board == null) {
            
        } else {
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

}
