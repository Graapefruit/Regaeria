using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private const float DIAGONAL_SPEED = 0.7071f; // 1 over root 2
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
        manageCameraMovements();
        manageSelection();
    }

    private void manageCameraMovements() {
        manageLateralMovement();
        manageScrollMovement();
        manageTurnScrolling();
    }

    private void manageLateralMovement() {
        float horizontalMovement = 0.0f;
        float verticalMovement = 0.0f;
        if (Input.GetKey(KeyCode.W)) {
            verticalMovement = 1.0f;
        } else if (Input.GetKey(KeyCode.S)) {
            verticalMovement = -1.0f;
        }
        if (Input.GetKey(KeyCode.A)) {
            horizontalMovement = -1.0f;
        } else if (Input.GetKey(KeyCode.D)) {
            horizontalMovement = 1.0f;
        }

        float movementModifier = (horizontalMovement != 0.0f && verticalMovement != 0.0f ? DIAGONAL_SPEED : 1.0f);
        movementModifier *= Time.deltaTime * cameraSpeed * (Input.GetKey(KeyCode.LeftShift) ? shiftCameraSpeedMultiplier : 1.0f);
        camera.transform.position = camera.transform.position + new Vector3(horizontalMovement * movementModifier, 0.0f, verticalMovement * movementModifier);
    }

    private void manageTurnScrolling() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            previousAction.Invoke();
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            nextAction.Invoke();
        }
    }

    private void manageScrollMovement() {
        // TODO
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
