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
    

    // Start is called before the first frame update
    void Start()
    {
        rot = transform.localRotation;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
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

        if(rotationReset && Quaternion.Angle(rot, transform.localRotation) > 90) 
        {
            playTimeline.startPlaying();

            handCrankAnimator.enabled = false;
            handCrankAnimator.gameObject.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");

            base.enabled = false;
        }
    }
}
