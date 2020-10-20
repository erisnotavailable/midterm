using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnd : MonoBehaviour
{
    public ScratchCount1 myScratchCount;
    public MoodCount myMoodCount;
    public bool isSpecialEnd;
    public bool requestEnd;
        void Update()
    {
        if(myScratchCount.fullScratchCount == true && myMoodCount.badMood == false)
        {
            isSpecialEnd = true;
        }
        if (Input.GetKeyUp(KeyCode.L)){
            requestEnd = true;
        }
        if (requestEnd == true && isSpecialEnd == true){
                GetComponent<SpriteRenderer>().color = new Color(1,1,1,255);
            
        }
        else{
                GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
            }
    }
}
