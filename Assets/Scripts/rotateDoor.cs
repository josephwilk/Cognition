using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class rotateDoor : MonoBehaviour
{
    public float timeUpdateMusic = 0.1f;

    public arduinoInput arduino;
    public PlayableDirector timeline;

    public AudioSource audioSource;

    public float valueClosed = 0;
    public float valueOpen = 1;

    public float rotationClosed = 0;
    public float rotationOpen = -70;

    public float currentValue;

    bool waitingForDoor = false;
    float lastPercentageOpen = 0;

    float timeSinceWaitingForDoor = 0;
    public float timeToShowHint = 20;
    public bool showHint = true;

    float lastTime = 0;


    public Animator doorAnimator;

   


    // Update is called once per frame
    void Update()
    {

        
        // get current value from arduino
        currentValue = arduino.value; 
        if(!showHint) currentValue = arduino.value2;

        float percentageOpen = (currentValue - valueClosed) / (valueOpen - valueClosed);
        Vector3 rot = new Vector3(0, Mathf.Lerp(rotationClosed, rotationOpen, percentageOpen), 0);

        transform.localEulerAngles = rot;



        if ((percentageOpen > 0.9 && waitingForDoor) || (Time.time - timeSinceWaitingForDoor > 40))
        {
            waitingForDoor = false;
            timeline.Resume();

            if(showHint) 
            {
                doorAnimator.enabled = false;
                doorAnimator.gameObject.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
            }
            

            //doorAnimator.gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.black);
            //doorAnimator.gameObject.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
            //doorHintAnimation.Stop();

        }

        

        if (!waitingForDoor) timeSinceWaitingForDoor = Time.time;
        else if (showHint && Time.time - timeSinceWaitingForDoor > timeToShowHint)
        {
            doorAnimator.enabled = true;
            doorAnimator.gameObject.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
        }

        //else if (Time.time - timeSinceWaitingForDoor > timeToShowHint) doorHintAnimation.Play();


        if (Time.time - lastTime >= timeUpdateMusic)
        {
            if (Mathf.Abs(lastPercentageOpen - percentageOpen) > 0.01f)
            {
                if(!audioSource.isPlaying) audioSource.Play();
            }
            else
            {
                if(audioSource.isPlaying) audioSource.Pause();
            }
            lastPercentageOpen = percentageOpen;
            lastTime = Time.time;
        }
    }

    public void setWaitingForDoor(bool waiting)
    {
        waitingForDoor = waiting;
    }


}
