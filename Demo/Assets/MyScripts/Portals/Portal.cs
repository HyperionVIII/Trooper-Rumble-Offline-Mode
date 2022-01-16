using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] public AudioSource portalSound;

    Transform destination;

    public bool isPortalGreenBlue;
    public float distance = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        if (isPortalGreenBlue == false)
        {
            destination = GameObject.FindGameObjectWithTag("PortalGreenBlue").GetComponent<Transform>();
        } else 
        {
            destination = GameObject.FindGameObjectWithTag("PortalGreenPurple").GetComponent<Transform>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Vector2.Distance(transform.position, other.transform.position) > distance)
        {
            other.transform.position = new Vector2(destination.position.x, destination.position.y);
            portalSound.Play();
        }
    }
}
