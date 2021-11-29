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

        if(director.state == PlayState.Paused && director.time > 0) 
        {
            // if at any time paused for more than 45 sec:
            if(Time.time - lastStopTime > 45)
            {
                director.Play();
            }

            // if nearly at end and paused for more than 25 sec:
            if(director.duration - director.time < 20 && Time.time - lastStopTime > 25) 
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
