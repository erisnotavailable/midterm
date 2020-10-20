using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoodCount : MonoBehaviour
{
    public Player myCat;
    public Me eris;
    public ScratchDetect detect;
    float stretchRate = 0.002f;
    float moodCount = 0f;
    float totalMood = 3f;
    float noMood = 0f;
    float halfMood = 1.5f;
    public bool badMood;
    void Update()
    {
        if(detect.detectScratching == true && myCat.scratching == true){
            moodCount += stretchRate;
            transform.localScale = new Vector3(totalMood - moodCount, 0.3f, 1f);
        }
        if(totalMood - moodCount < 0f){
            transform.localScale = new Vector3(noMood, 0.3f, 1f);
        }
        if(totalMood - moodCount< halfMood){
            badMood = true;
            Debug.Log("badmood");
        }
    }
}
