using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRotation : MonoBehaviour
{
    public float rotationSpeed;

    void FixedUpdate()
    {
        transform.Rotate(0, -3 * rotationSpeed, 0 );
    }
}