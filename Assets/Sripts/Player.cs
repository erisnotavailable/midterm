using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    public bool isJumping;
    public bool onGround;
    public bool scratchingLeft;
    public bool scratchingRight;
    public bool scratching;
    public bool hasScratched;
    float inputHorizontal;
    float moveSpeed = 4f;
    float jumpForce = 15f;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        //tell the position of the cat
        float catLocation = transform.position.x;

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
            //Debug.Log(" on ground");
        }
        else{
            onGround = false;
        }

        //use raycasting to check if the cat can scratch left
        float leftrayLength = 0.9f;
        Ray2D leftRay = new Ray2D(transform.position, Vector2.left);   
        RaycastHit2D leftRayHit = Physics2D.Raycast(leftRay.origin, leftRay.direction, leftrayLength);
        if (leftRayHit.collider != null && Input.GetKey(KeyCode.K)) {
            showMsg(leftRayHit.collider.name);
        } else {
            showMsg("close");
        }
        if (leftRayHit.collider != null && Input.GetKey(KeyCode.J)){
            scratchingLeft = true;
            Debug.Log("scratch left");
        }
        else{
            scratchingLeft = false;
        }

        //if the cat can scratch left and J is pressed, scratch left
        float rightrayLength = 0.9f;
        Ray2D rightRay = new Ray2D(transform.position, Vector2.right);
        RaycastHit2D rightRayHit = Physics2D.Raycast(rightRay.origin, rightRay.direction, rightrayLength);
        if (rightRayHit.collider != null && Input.GetKey(KeyCode.K)) {
            showMsg(rightRayHit.collider.name);
        } else {
            showMsg("close");
        }
        if (rightRayHit.collider != null && Input.GetKey(KeyCode.J)){
            scratchingRight = true;
            Debug.Log("scratch right");
        }
        else{
            scratchingRight = false;
        }

        //above all, is it scratching?
        if(scratchingLeft == true || scratchingRight == true){
            scratching = true;
        }
        else{
            scratching = false;
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

    void showMsg(string furniture) {
        GameObject.Find("messageBox").GetComponent<SpriteRenderer>().color = new Color(1,1,1,255);

        switch(furniture) {
        case "sofa0":
        case "sofa1":
        case "sofa2":
            GameObject.Find("textToShow").GetComponent<Text>().text = "Soft, ideal for scratching. She gets upset when I do so.";
            break;
        case "bed0":
        case "bed1":
            GameObject.Find("textToShow").GetComponent<Text>().text = "I wonder why she chose such small and dark bedroom.";
            break;
        case "pillow":
            GameObject.Find("textToShow").GetComponent<Text>().text = "She slept days and nights when she was in high school. I stayed with her at that time.";
            break;
        case "desk0":
        case "desk1":
        case "desk2":
            GameObject.Find("textToShow").GetComponent<Text>().text = "She stays here quite a lot. I know she can paint a lot of stuff on this thing. Will she paint me?";
            break;
        case "mirror":
            GameObject.Find("textToShow").GetComponent<Text>().text = "She looks into the mirror even less than me. Is she afraid of her own face?";
            break;
        case "door":
            GameObject.Find("textToShow").GetComponent<Text>().text = " I definitely will go through this door one day.";
            break;
        case "books":
            GameObject.Find("textToShow").GetComponent<Text>().text = "She read quite a lot.";
            break;
        case "photo":
            GameObject.Find("textToShow").GetComponent<Text>().text = "A photo of her parents. I think they tried to send her to business school years ago.";
            break;
        case "stove":
        case "cabinet":
            GameObject.Find("textToShow").GetComponent<Text>().text = "She actually enjoys cooking, especially when due dates are near.";
            break;
        case "table0":
        case "table1":
        case "chair0":
        case "chair1":
            GameObject.Find("textToShow").GetComponent<Text>().text = "Jumping up and down is so much fun.";
            break;
        case "close":
            GameObject.Find("messageBox").GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
            GameObject.Find("textToShow").GetComponent<Text>().text = "";
            Debug.Log("closed");
            break;
        //default:
        //    GameObject.Find("textToShow").GetComponent<Text>().text = "text to show";
        //    break;
        }
    }
}
