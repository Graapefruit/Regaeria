using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// All player inputs are to first go through this class for traceability
public class PlayerInputController : MonoBehaviour
{
    public Vector2Reference wasdShift;
    public FloatReference scrollShift;
    public BoolReference isMouseOverBlockingUiElement;
    public GameEvent leftMouseDownEvent;
    public GameEvent rightMouseDownEvent;

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
        if (Input.GetMouseButtonDown(1)) {
            rightMouseDownEvent.Raise();
        }

        isMouseOverBlockingUiElement.set(mouseOverBlockingUiElement());
    }

    //https://forum.unity.com/threads/how-to-detect-if-mouse-is-over-ui.1025533/
    private bool mouseOverBlockingUiElement() {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);

        for (int index = 0; index < raysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = raysastResults[index];
            if (curRaysastResult.gameObject.layer == LayerDefinitions.UI_BLOCKING_LAYER) {
                return true;
            }
        }
        return false;
    }
}
