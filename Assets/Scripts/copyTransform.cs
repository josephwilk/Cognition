using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copyTransform : MonoBehaviour
{

    public bool position = true;
    public bool rotation = true;

    public GameObject copyFrom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(position) transform.position = copyFrom.transform.position;
        if(rotation) transform.rotation = copyFrom.transform.rotation;
    }
}
