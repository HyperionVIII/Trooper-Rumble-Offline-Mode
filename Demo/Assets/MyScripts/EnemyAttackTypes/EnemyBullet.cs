using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;

    // lines of code in the start method are run only once
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed; // calculates the direction at which the target is
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y); // moves towards the target
        Destroy(this.gameObject, 1);
    }

}