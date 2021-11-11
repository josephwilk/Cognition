using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class playTimeline : MonoBehaviour
{

    public PlayableDirector director;

    private void OnEnable()
    {
        director.time = 0;
        director.Play();
    }
}
