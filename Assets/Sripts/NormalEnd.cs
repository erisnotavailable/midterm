using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnd : MonoBehaviour
{
    public ScratchCount1 myScratchCount;
    public MoodCount myMoodCount;
    public bool isNormalEnd;
    public bool requestEnd;
    void Update()
    {
        if(myScratchCount.fullScratchCount == false && myMoodCount.badMood == false)
        {
            isNormalEnd = true;
        }
        if (Input.GetKeyUp(KeyCode.L)){
            requestEnd = true;
        }
        if (requestEnd == true && isNormalEnd == true){
                GetComponent<SpriteRenderer>().color = new Color(1,1,1,255);
                Debug.Log("normalend");
            
        }
        else{
                GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
                Debug.Log("noend");
            }
    }
    
}
