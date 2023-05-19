using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public Vector2Reference wasdShift;
    public FloatReference scrollShift;

    void Update()
    {
        scrollShift.set(Input.mouseScrollDelta.y);

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
}
