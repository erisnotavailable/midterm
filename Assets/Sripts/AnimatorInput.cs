using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorInput : MonoBehaviour
{
    Animator myAnimator; 
    void Start()
    {
      myAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        //these codes detects if the cat is walking to a certain direction or idle
        if (Input.GetKey(KeyCode.A)){
                myAnimator.SetBool ("walkLeft" , true);
                //transform.Translate (Time.deltaTime, 0, 0);
                Debug.Log("left");
            }
            else {
                myAnimator.SetBool ("walkLeft" , false);
            }
        if (Input.GetKey(KeyCode.D)){
                myAnimator.SetBool ("walkRight" , true);
                //transform.Translate (Time.deltaTime, 0, 0);
                Debug.Log("Right");
            }    
            else{
                myAnimator.SetBool ("walkRight" , false);
            }
        if (!Input.anyKey){
                myAnimator.SetBool ("idle" , true);
                Debug.Log("idle");
        }
        else{
                myAnimator.SetBool ("idle" , false);
            }
        
        //these codes use raycasting to detect whether the cat can scratch left
        float leftrayLength = 0.9f;
        Ray2D leftRay = new Ray2D(transform.position, Vector2.left);
        Debug.DrawRay(leftRay.origin, leftRay.direction*leftrayLength, Color.blue);   
        RaycastHit2D leftRayHit = Physics2D.Raycast(leftRay.origin, leftRay.direction, leftrayLength);
        if (leftRayHit.collider != null){
            myAnimator.SetBool ("canScratchLeft" , true);
            Debug.Log("can scratch left");
        }
        else{
            myAnimator.SetBool ("canScratchLeft" , false);
        }

        //and if the cat is trying to scratch left

        if (Input.GetKey(KeyCode.J)){
            myAnimator.SetBool ("scratchingLeft" , true);
            myAnimator.SetBool ("scratchingRight" , true);
            }
        else{
            myAnimator.SetBool ("scratchingLeft" , false);
            myAnimator.SetBool ("scratchingRight" , false);
        }

        //same thing with right
        float rightrayLength = 0.9f;
        Ray2D rightRay = new Ray2D(transform.position, Vector2.right);
        Debug.DrawRay(rightRay.origin, rightRay.direction*rightrayLength, Color.blue);   
        RaycastHit2D rightRayHit = Physics2D.Raycast(rightRay.origin, rightRay.direction, rightrayLength);
        if (rightRayHit.collider != null){
            myAnimator.SetBool ("canScratchRight" , true);
            Debug.Log("can scratch right");
        }
        else{
            myAnimator.SetBool ("canScratchRight" , false);
        }

        //and if the cat is trying to scratch left

        
    }
}
