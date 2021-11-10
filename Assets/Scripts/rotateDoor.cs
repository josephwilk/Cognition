using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class rotateDoor : MonoBehaviour
{
    public arduinoInput arduino;
    public PlayableDirector timeline;

    public float valueClosed = 0;
    public float valueOpen = 1;

    public float rotationClosed = 0;
    public float rotationOpen = -70;

    public float currentValue;

    bool waitingForDoor = false;

    // Update is called once per frame
    void Update()
    {
        // get current value from arduino
        currentValue = arduino.value; 

        float percentageOpen = (currentValue - valueClosed) / (valueOpen - valueClosed);
        Vector3 rot = new Vector3(0, Mathf.Lerp(rotationClosed, rotationOpen, percentageOpen), 0);

        transform.localEulerAngles = rot;



        if (percentageOpen > 0.9 && waitingForDoor)
        {
            waitingForDoor = false;
            timeline.Resume();
        }

    }

    public void setWaitingForDoor(bool waiting)
    {
        waitingForDoor = waiting;
    }


}
