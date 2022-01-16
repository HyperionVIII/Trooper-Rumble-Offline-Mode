using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSound : MonoBehaviour
{
    [SerializeField] public AudioSource collectSoundEffect;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heal"))
        {
            collectSoundEffect.Play();
        }
    }
}