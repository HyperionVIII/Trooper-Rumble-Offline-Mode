using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2 : MonoBehaviour
{
    [SerializeField] public AudioSource portalSound;

    Transform destination;

    public bool isPortalGreen;
    public float distance = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        if (isPortalGreen == false)
        {
            destination = GameObject.FindGameObjectWithTag("PortalGreen").GetComponent<Transform>();
        }
        else
        {
            destination = GameObject.FindGameObjectWithTag("PortalGreenYellow").GetComponent<Transform>();
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

