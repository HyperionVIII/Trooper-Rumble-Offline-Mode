using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed =10f;
    public float timeToLive;
    public Rigidbody2D bulletBody;
    public int damage = 30;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        bulletBody.velocity = transform.right * bulletSpeed;
        Destroy(gameObject, 5);    // THIS IS THE ONLY THING WE NEED TO DESTROY THE BULLET AUTOMATICALLY AFTER 5 SECONDS 
    }
    void OnTriggerEnter2D(Collider2D hitInfo){
        print(hitInfo.name);
        Destroy(gameObject); // gameObject ---> Bullet
        }
    }