using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] public AudioSource gunShotSound;

    public Transform shootingPoint;
    public GameObject bulletPrefab;

    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            shoot();

        }
        
    }
    public void shoot(){
        
        Instantiate(bulletPrefab,shootingPoint.position,shootingPoint.rotation);
        gunShotSound.Play();
       // print("shooting...");
    }
}