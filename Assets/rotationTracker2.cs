using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationTracker2 : MonoBehaviour
{
    public Transform tracker1;
    public Transform tracker2;
    public Transform similarCube;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = tracker2.position - tracker1.position;

        //transform.forward = Vector3.ProjectOnPlane(direction, similarCube.up);
        transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(direction, similarCube.up), similarCube.up);
        //transform.forward = Vector3.Cross(Vector3.Cross(similarCube.up, direction), similarCube.up);
        // Vector3 rot = transform.localEulerAngles;
        // rot.x = 0;
        // rot.z = 0;
        // transform.localEulerAngles = rot;
    }
}
