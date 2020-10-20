using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEnd : MonoBehaviour
{
    public ScratchCount1 myScratchCount;
    public MoodCount myMoodCount;
    public bool isBadEnd;
    public bool requestEnd;
    

    // Update is called once per frame
    void Update()
    {
      if(myScratchCount.fullScratchCount == false && myMoodCount.badMood == true)
        {
            isBadEnd = true;
        }
        if (Input.GetKeyUp(KeyCode.L)){
            requestEnd = true;
        }
        if (requestEnd == true && isBadEnd == true){
                GetComponent<SpriteRenderer>().color = new Color(1,1,1,255);
            
        }
        else{
                GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
            }
    }  
    
}
