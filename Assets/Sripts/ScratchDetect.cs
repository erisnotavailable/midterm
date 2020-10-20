using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchDetect : MonoBehaviour
{
    public Player myCat;
    public Me eris;
    float detectDistance = 6f;
    public bool detectScratching;

    void Update()
    {
        float distance = myCat.transform.position.x - eris.transform.position.x;
        if(distance < detectDistance && distance > detectDistance * -1){
            detectScratching = true;
            Debug.Log("is within range");
        }
        else{
            detectScratching = false;
            Debug.Log("is out of sight");
        }
    }
    
}
