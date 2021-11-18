using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationBasedOnTracker : MonoBehaviour
{

    public GameObject rotatingTracker;
    public float rotFactor;
    public enum Axis
    {
        x,y,z
    }
    public Axis axis;

    int axisIndex;
    //float lastTrackerRot;

    Quaternion lastTrackerRot;

    // Start is called before the first frame update
    void Start()
    {
        if (axis == Axis.x) axisIndex = 0;
        else if (axis == Axis.y) axisIndex = 1;
        else axisIndex = 2;

        //lastTrackerRot = rotatingTracker.transform.localEulerAngles.x;
        lastTrackerRot = rotatingTracker.transform.localRotation;


        // Quaternion currentTrackerRotation = rotatingTracker.transform.localRotation;

        // float rotAngle = Quaternion.Angle(lastTrackerRot, currentTrackerRotation);

        // Vector3 rot = new Vector3();

        // int direction = 1;
        // if(Vector3.Cross(Quaternion.ToEulerAngles(lastTrackerRot), Quaternion.ToEulerAngles(currentTrackerRotation)).y > 0) direction = -1;

        // rot[axisIndex] = rotAngle * rotFactor * direction;

        // transform.Rotate(rot);

        // lastTrackerRot = currentTrackerRotation;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rotatingTracker.transform.localEulerAngles.y);

        //Vector3 rot = transform.localEulerAngles;
        //rot[axisIndex] = rotFactor * rotatingTracker.transform.localEulerAngles.y;
        //transform.localEulerAngles = rot;
        //float currentTrackerRot = rotatingTracker.transform.localEulerAngles.x;

        //Vector3 rot = new Vector3();
        //int p = 0;
        //if (currentTrackerRot < 10 || currentTrackerRot > 350) p = 60;
        //rot[axisIndex] = (((currentTrackerRot + p) % 360 - (lastTrackerRot + p) % 360)) * rotFactor;

        //transform.Rotate(rot);

        //lastTrackerRot = currentTrackerRot;


        Quaternion currentTrackerRotation = rotatingTracker.transform.localRotation;

        Quaternion rotation = Quaternion.Inverse(lastTrackerRot) * currentTrackerRotation;

        transform.rotation *= Quaternion.SlerpUnclamped(Quaternion.identity, rotation, rotFactor) ;


        // float rotAngle = Quaternion.Angle(lastTrackerRot, currentTrackerRotation);

        // Vector3 rot = new Vector3();

        // int direction = 1;
        // //if(Vector3.Cross(Quaternion.ToEulerAngles(lastTrackerRot), Quaternion.ToEulerAngles(currentTrackerRotation)).y > 0) direction = -1;

        // rot[axisIndex] = rotAngle * rotFactor * direction;

        // transform.Rotate(rot);

        lastTrackerRot = currentTrackerRotation;
        
    }
}
