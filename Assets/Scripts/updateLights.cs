using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateLights : MonoBehaviour
{

    public GameObject tracker;


    // Start is called before the first frame update
    void Start()
    {
        //transform.SetPositionAndRotation(tracker.transform.position, tracker.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.SetPositionAndRotation(tracker.transform.position, tracker.transform.rotation);
        base.enabled = false;
    }
}
