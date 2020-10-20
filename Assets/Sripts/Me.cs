using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Me : MonoBehaviour
{
   
    float walkFlip = -3.5f;
    float detectLength = 3f;
    float countdown = 5f;
    float timer = 0f;
    void Update()
    {
        //get my x location
        float myLocation = transform.position.x;
        //decide how i walk
        transform.Translate(walkFlip * Time.deltaTime, 0f, 0f);

        //raycast for left
        Ray2D leftDetect = new Ray2D (transform.position, Vector2.left);
        
        Debug.DrawRay(leftDetect.origin, leftDetect.direction * detectLength, Color.yellow);
        RaycastHit2D leftDetectHit = Physics2D.Raycast(leftDetect.origin, leftDetect.direction, detectLength);
        
        //raycast for right
        Ray2D rightDetect = new Ray2D (transform.position, Vector2.right);
        
        Debug.DrawRay(rightDetect.origin, rightDetect.direction * detectLength, Color.yellow);
        RaycastHit2D rightDetectHit = Physics2D.Raycast(rightDetect.origin, rightDetect.direction, detectLength);
       
        
        //check if hit, if so, turn around
        if (leftDetectHit.collider != null){
            transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
            walkFlip = walkFlip * -1 ;
            //Debug.Log("raycast turned");
        }
        //same thing with right side
        if (rightDetectHit.collider != null){
            transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
            walkFlip = walkFlip * -1 ;
            //Debug.Log("raycast turned");
        }

        //for every 5 seconds, decide if i turn around.
        //first, make a timer
        timer += Time.deltaTime;
        if (timer > countdown){
            timer = timer - countdown;
            //Debug.Log("cleared");

            float random = Random.Range(0,10);

            if (random < 5){
                transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
                walkFlip = walkFlip * -1 ;
                //Debug.Log("turned");
            }
            else{
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
            
            }
        }

    }
}
