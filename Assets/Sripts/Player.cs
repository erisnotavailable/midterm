using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    public bool isJumping;
    public bool canJump = true;

    public bool onGround;
    float inputHorizontal;
    float moveSpeed = 6f;
    float jumpForce = 16f;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
            if (Input.GetButtonDown("Jump") && onGround == true){
            isJumping = true;
            }
        
    }

    void FixedUpdate()
    {
        myRigidBody.velocity = new Vector2(inputHorizontal*moveSpeed, myRigidBody.velocity.y);
        
            if (isJumping) {
            myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
            isJumping = false;
            }     
    }
}
