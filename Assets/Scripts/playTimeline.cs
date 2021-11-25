using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayTimeline : MonoBehaviour
{
    public PlayableDirector director;
    
    float lastStopTime;

    private void Update() 
    {
        if(director.state == PlayState.Playing)
        {
            lastStopTime = Time.time;
        }

        if(director.state == PlayState.Paused) 
        {
            if(Time.time - lastStopTime > 45)
            {
                director.Play();
            }
        }


    }

    public void startPlaying()
    {
        director.time = 0;
        director.Play();
    }


}
