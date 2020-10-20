using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchCount1 : MonoBehaviour
{
    public Player myCat;
    public Me eris;

    
    float stretchRate = 0.001f;
    float scratchCount = 0f;
    float enoughScratch = 3f;
    public bool notHalfScratchCount;
    public bool fullScratchCount;
    void Update()
    {
        if(myCat.scratching == true)
        {
            scratchCount += stretchRate;
            transform.localScale = new Vector3(scratchCount, 0.3f, 1f);
        }
        if(scratchCount >= enoughScratch){
            transform.localScale = new Vector3(enoughScratch, 0.3f, 1f);
            fullScratchCount = true;
            Debug.Log("scratched full time!");
        }
    }
}
