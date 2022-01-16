using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotation : MonoBehaviour
{
    public float rotationSpeed;

    void FixedUpdate()
    {
        transform.Rotate(0, 0, -3 * rotationSpeed);
    }
}