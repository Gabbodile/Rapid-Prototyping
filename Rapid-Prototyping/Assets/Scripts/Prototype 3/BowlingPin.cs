using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    bool knockedOver = false;
    void Update()
    {
        if (transform.up.y < 0.5f && !knockedOver)
        {
            knockedOver = true;
            Destroy(this.gameObject, 5);
        }
    }
}
