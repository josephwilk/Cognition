using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copyTransform : MonoBehaviour
{

    public GameObject copyFrom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = copyFrom.transform.position;
        transform.rotation = copyFrom.transform.rotation;
    }
}
