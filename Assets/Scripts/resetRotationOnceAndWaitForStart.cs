using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetRotationOnceAndWaitForStart : MonoBehaviour
{

    public float targetTime;

    public PlayTimeline playTimeline;

    Quaternion rot;
    float startTime;
    bool rotationReset = false;

    public float timeToShowHint = 20;
    public Animator handCrankAnimator;

    public AudioSource audioSource;
    float lastTime = 0;
    public float timeUpdateMusic = 0.1f;
    Quaternion lastRotation;


    bool timelineStarted = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rot = transform.localRotation;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(!timelineStarted) 
        {
            if(Time.time - startTime > timeToShowHint)
            {
                handCrankAnimator.enabled = true;
                handCrankAnimator.gameObject.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
            }

            if(!rotationReset && Time.time - startTime > targetTime) 
            {
                transform.localRotation = rot;
                rotationReset = true;
                rot = transform.localRotation;
            }

            if((rotationReset && Quaternion.Angle(rot, transform.localRotation) > 90) || Time.time - startTime > 60) 
            {
                playTimeline.startPlaying();

                handCrankAnimator.enabled = false;
                handCrankAnimator.gameObject.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");

                // base.enabled = false;
                timelineStarted = true;
            }
        }
         

         
        if (Time.time - lastTime >= timeUpdateMusic)
        {
            // if (Quaternion.Angle(lastRotation, transform.localRotation) > 1)
            // {
            //     if(!audioSource.isPlaying) audioSource.Play();
            // }
            // else
            // {
            //     if(audioSource.isPlaying) audioSource.Pause();
            // }

            audioSource.volume = Mathf.Lerp(0.1f, 1, Quaternion.Angle(lastRotation, transform.localRotation) / 10);

            lastRotation = transform.localRotation;
            lastTime = Time.time;
        }
        
    }
}
