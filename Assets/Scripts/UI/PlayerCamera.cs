using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private const float DIAGONAL_SPEED_MODIFIER = 0.7071f; // 1 over root 2, via pythagoras
    private const float CAMERA_BASE_SPEED = 8.0f;
    private const float CAMERA_BONUS_SPEED_MODIFIER = 3.0f;
    private const float CAMERA_BASE_SCROLL_SPEED = 32.0f;
    private const float MAX_SCROLL_IN = 5.5f;
    private const float MAX_SCROLL_OUT = 4.5f;
    public Vector2Reference wasdShift;
    public GameEvent mouseMoveEvent;
    public FloatReference scrollShift;
    public Vector3Reference projectedMousePosition;
    private float maxHeight;
    private float minHeight;
    private Vector3? lastMousePosition;

    void Awake()  {
        lastMousePosition = Vector3.zero;
        maxHeight = transform.position.y + MAX_SCROLL_OUT;
        minHeight = transform.position.y - MAX_SCROLL_IN;
    }

    void Update() {
        updatePosition();
        handleMouseMovement();
    }

    private void updatePosition() {
        Vector2 wasdMovement = wasdShift.get();
        float movementModifier = (wasdMovement.x != 0.0f && wasdMovement.y != 0.0f ? DIAGONAL_SPEED_MODIFIER : 1.0f);
        movementModifier *= Time.deltaTime * CAMERA_BASE_SPEED * (Input.GetKey(KeyCode.LeftShift) ? CAMERA_BONUS_SPEED_MODIFIER : 1.0f);

        float scrollDelta = Time.deltaTime * CAMERA_BASE_SCROLL_SPEED * scrollShift.get() * -1.0f;
        scrollDelta = (transform.position.y + scrollDelta > maxHeight ? maxHeight - transform.position.y : scrollDelta);
        scrollDelta = (transform.position.y + scrollDelta < minHeight ? transform.position.y - minHeight : scrollDelta);
        transform.position += new Vector3(wasdMovement.x * movementModifier, scrollDelta, wasdMovement.y * movementModifier);
    }

    private void handleMouseMovement()
    {
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        projectedMousePosition.set(Physics.Raycast(ray, out hit) ? (Vector3?)hit.point : null);

        if (projectedMousePosition.get() != lastMousePosition) {
            mouseMoveEvent.Raise();
        }

        lastMousePosition = projectedMousePosition.get();
    }
}
