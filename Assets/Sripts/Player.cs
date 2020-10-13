using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D myRigidBody;

    public bool isJumping;
    public bool onGround;
    public bool canScratchLeft;
    float inputHorizontal;
    float moveSpeed = 4f;
    float jumpForce = 15f;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //basic moving input. 
        //ad to go left and right, space to jump if onground
        inputHorizontal = Input.GetAxis("Horizontal");
            if (Input.GetButtonDown("Jump") && onGround == true){
            isJumping = true;
            }
            
        //use raycasting to check if the cat is onground
        //if so, the cat can jump
        float rayLength = 0.7f;
        Ray2D myRay = new Ray2D(transform.position, Vector2.down);
        Debug.DrawRay(myRay.origin, myRay.direction*rayLength, Color.white);   
        RaycastHit2D myRayHit = Physics2D.Raycast(myRay.origin, myRay.direction, rayLength);
        if (myRayHit.collider != null){
            onGround = true;
            Debug.Log(" on ground");
        }
        else{
            onGround = false;
        }

        //use raycasting to check if the cat can scratch left
        float leftrayLength = 0.9f;
        Ray2D leftRay = new Ray2D(transform.position, Vector2.left);   
        RaycastHit2D leftRayHit = Physics2D.Raycast(leftRay.origin, leftRay.direction, leftrayLength);
        if (leftRayHit.collider != null){
            canScratchLeft = true;
        }
        else{
            canScratchLeft=false;
        }

        //if the cat can scratch left and J is pressed, scratch left
        
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
