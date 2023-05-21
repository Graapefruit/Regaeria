using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// All player inputs are to first go through this class for traceability
public class PlayerInputController : MonoBehaviour
{
    public Vector2Reference wasdShift;
    public FloatReference scrollShift;
    public GameEvent leftMouseDownEvent;
    public GameEvent rightMouseDownEvent;
    private Vector3 lastMousePos;

    void Update()
    {
        scrollShift.set(Input.mouseScrollDelta.y);
        recordDirectionalKeyInput();
        recordMouseInputs();
    }

    private void recordDirectionalKeyInput() {
        Vector2 newWasdShift = new Vector2(0.0f, 0.0f);
        
        if (Input.GetKey(KeyCode.W)) {
            newWasdShift.y = 1.0f;
        } else if (Input.GetKey(KeyCode.S)) {
            newWasdShift.y = -1.0f;
        }

        if (Input.GetKey(KeyCode.A)) {
            newWasdShift.x = -1.0f;
        } else if (Input.GetKey(KeyCode.D)) {
            newWasdShift.x = 1.0f;
        }

        wasdShift.set(newWasdShift);
    }

    private void recordMouseInputs() {
        if (Input.GetMouseButtonDown(0)) {
            leftMouseDownEvent.Raise();
        }
        if (Input.GetMouseButtonDown(0)) {
            rightMouseDownEvent.Raise();
        }
    }
}
