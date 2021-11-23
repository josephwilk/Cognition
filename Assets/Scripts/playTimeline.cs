using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayTimeline : MonoBehaviour
{

    public PlayableDirector director;
    

    public void startPlaying()
    {
        director.time = 0;
        director.Play();
    }
}
