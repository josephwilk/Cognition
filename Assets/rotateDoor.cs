using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateDoor : MonoBehaviour
{
    public float valueClosed = 0;
    public float valueOpen = 1;

    public float rotationClosed = 0;
    public float rotationOpen = -70;

    public float currentValue;

    // Update is called once per frame
    void Update()
    {
        float percentageOpen = (currentValue - valueClosed) / (valueOpen - valueClosed);
        Vector3 rot = new Vector3(0, Mathf.Lerp(rotationClosed, rotationOpen, percentageOpen), 0);

        transform.localEulerAngles = rot;
    }
}
