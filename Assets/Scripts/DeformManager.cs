using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeformManager : MonoBehaviour
{

    private MeshHeightMapDeform[] agents;

    [Range(0.00f, 0.09f)]
    public float targetHeight = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        agents = GetComponentsInChildren<MeshHeightMapDeform>();


    }

    // Update is called once per frame
    void Update()
    {
        foreach (var agent in agents)
        {
            agent.height = targetHeight;
            
        }

    }
}
