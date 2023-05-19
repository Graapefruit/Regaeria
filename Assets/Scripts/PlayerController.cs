using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    public float cameraSpeed = 8.0f;
    public float shiftCameraSpeedMultiplier = 3.0f;
    new private Camera camera;
    public BoardInputHandler board;
    public UnityEvent previousAction;
    public UnityEvent nextAction;
    void Awake() {
        camera = transform.GetChild(0).GetComponent<Camera>();
    }
    void Update() {
        manageSelection();
    }

    private void manageTurnScrolling() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            previousAction.Invoke();
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            nextAction.Invoke();
        }
    }

    private void manageSelection() {
        if (board != null) {
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
