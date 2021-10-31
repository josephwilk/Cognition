using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{

    public GameObject objectToLookAt;
    public GameObject boneToRotate;
    public GameObject secondBoneToRotate;
    public GameObject referenceBone;

    public float verticalOffset;

    public float sideMultiplier = 1;

    public float lerpParam = 0.1f;

    private void Start()
    {
       // up = boneToRotate.transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (objectToLookAt.transform.position - boneToRotate.transform.position).normalized;
        //Vector3 lookUp = 

        Vector3 wantedRotation = Vector3.Lerp(secondBoneToRotate.transform.forward, (lookDirection +referenceBone.transform.forward)/2, lerpParam);
        secondBoneToRotate.transform.forward = wantedRotation;//new Vector3(secondBoneToRotate.transform.forward.x, secondBoneToRotate.transform.forward.y, lookDirection.z);
        //secondBoneToRotate.transform.Rotate(new Vector3(0, lookDirection.y - secondBoneToRotate.transform.eulerAngles.y, 0));

        boneToRotate.transform.forward = Vector3.Lerp(boneToRotate.transform.forward, lookDirection + new Vector3(0, verticalOffset, 0), lerpParam);
        boneToRotate.transform.RotateAround(boneToRotate.transform.forward, -objectToLookAt.transform.rotation.z * sideMultiplier);
    }
}
