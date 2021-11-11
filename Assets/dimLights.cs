using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dimLights : MonoBehaviour
{
    public float dimValue = 1; //between 0 and 1

    Light[] lights;
    float[] maxBrightnesses;

    // Start is called before the first frame update
    void Start()
    {
        lights = GetComponentsInChildren<Light>();
        maxBrightnesses = new float[lights.Length];
        for(int i = 0; i < lights.Length; i++)
        {
            maxBrightnesses[i] = lights[i].intensity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < lights.Length; i++)
        {
            lights[i].intensity = maxBrightnesses[i] * dimValue;
        }
    }
}
