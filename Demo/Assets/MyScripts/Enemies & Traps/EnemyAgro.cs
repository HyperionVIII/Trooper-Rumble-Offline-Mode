using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgro : MonoBehaviour
{

    public float speed;
    public float lineOfSite; //Enemy's range
    public float shootingRange; //How far the enemy will go
    public float fireRate = 1f;
    public float nextFireTime;
    public GameObject bullet; // Enemy's bullet
    public GameObject bulletParent; // the place from where we will shoot the bullet
    public Transform player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // to make enemy detect player after being in a certain range from the player
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange) // to make the enemy move if the player
                                                                                   // is in its line of sight, but it will
                                                                                   // not move if it's just in his shooting range
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }

        else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time) 
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate; // which will make our enemy shoot bullets at a certain fire rate which in
                                                 // our case is one second because the value of fireRate above is 1f
        }
        // The "bullet parent" is where the bullet gets instantaited from // Quaternion.identity means no rotation is possible
    }
        
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        //these 2 radii we set up down below is to make the enemy only move when we are in a line of sight and stop when we are in the shooting range
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}