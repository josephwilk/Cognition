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


    // Start is called before the first frame update
    void Start()
    {
        rot = transform.localRotation;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(!rotationReset && Time.time - startTime > targetTime) 
        {
            transform.localRotation = rot;
            rotationReset = true;
            rot = transform.localRotation;
        }

        if(rotationReset && Quaternion.Angle(rot, transform.localRotation) > 90) 
        {
            playTimeline.startPlaying();
            base.enabled = false;
        }
    }
}
