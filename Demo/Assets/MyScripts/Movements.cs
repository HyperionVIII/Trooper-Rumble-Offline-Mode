using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using Photon.Pun;

public class Movements : MonoBehaviour
{
    public float UIMov; // can be left or right (1/-1)
    public SpriteRenderer sr;
    public float movementX;
    //////
    public float moveSpeed = 10f;
    public float jumpSpeed = 11f;
    //////

    //////
    public Rigidbody2D body;
    public Collider2D coll;
    //////
    public bool isFacingRight = true;
    public bool isOnGround = true; //to prevent him from jumping from air
                                   //////
                                   //public PhotonView view;

    [SerializeField] public AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        //view = GetComponent<PhotonView>(); 
    }
    // void Awake(){
    //     //view = GetComponent<PhotonView>();
    //     //body = GetComponent<Rigidbody2D>();
    //     //coll = GetComponent<BoxCollider2D>();
    //     //view = GetComponent<PhotonView>();        
    // }

    // Update is called once per frame
    void Update()
    {
        // if(view.IsMine){
        playerMovements();
        playerJump();
        // }

    }

    public void playerJump()
    {
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            isOnGround = false;
            body.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
            jumpSoundEffect.Play();
        }        
    }



    public void playerMovements()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position = transform.position + new Vector3(movementX, 0f, 0f) * moveSpeed * Time.deltaTime;
        // UI Buttons
        transform.position = transform.position + new Vector3(UIMov, 0f, 0f) * moveSpeed * Time.deltaTime;
        // flip
        if (movementX < 0 && isFacingRight)
        {
            //view.RPC("flip",Photon)
            flip();
        }
        else if (movementX > 0 && !isFacingRight)
        {
            flip();
        }
    }

    //[PunRPC]
    void flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        //if (collision.gameObject.tag == "Enemy" && !particlesSpawned) Death(); ///////
    }

    public void ButtonJump()
    {
        if (isOnGround)
        {
            isOnGround = false;
            body.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
        }
    }

    ////// moving the player with UI buttons
    public void movRight()
    {
        UIMov = 1;
    }

    public void movLeft()
    {
        UIMov = -1;
    }

    public void stopUImov()
    {
        UIMov = 0;
    }

    public void printSomething()
    {
        print("something");
    }
}//class