using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public Player myCat;
    public Me eris;
    public ScratchDetect detect;
    float  detectDistance = 6f;

    void Update()
    {
        float distance = myCat.transform.position.x - eris.transform.position.x;
        if(detect.detectScratching == true && myCat.scratching == true){
            GetComponent<SpriteRenderer>().color = new Color(1,1,1,255);
            //Debug.Log("sign lit up");
        }
        else{
            GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
            //Debug.Log("sign disappear");
        }
        
    }
}
