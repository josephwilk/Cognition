using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{

    public GameObject objectToLookAt;
    public GameObject boneToRotate;

    public float verticalOffset;

    public float sideMultiplier = 1;

    private void Start()
    {
       // up = boneToRotate.transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (objectToLookAt.transform.position - boneToRotate.transform.position).normalized;
        //Vector3 lookUp = 

        boneToRotate.transform.forward = lookDirection + new Vector3(0, verticalOffset, 0);
        boneToRotate.transform.RotateAround(boneToRotate.transform.forward, -objectToLookAt.transform.rotation.z * sideMultiplier);
    }
}
