using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotation : GameBehaviour
{
    public Transform cannonBarrel;
    public float scrollSpeed = 10;
    public float minAngle = -45.0f;
    public float maxAngle = 45.0f;

    void Update()
    {
        float rotateCannon = Input.GetAxis("Mouse X");
        transform.Rotate(0, rotateCannon, 0);

        cannonBarrel.Rotate(Input.mouseScrollDelta.y * scrollSpeed, 0, 0);
        float YaxisRotation = Mathf.Clamp(Input.mouseScrollDelta.y, minAngle, maxAngle);
    }
}
