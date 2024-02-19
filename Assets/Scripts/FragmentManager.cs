using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentManager : MonoBehaviour
{

    private FractureMover[] agents;

    [Range(0.00f, 0.09f)]
    public float motion = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        agents = GetComponentsInChildren<FractureMover>();
        

    }

    // Update is called once per frame
    void Update()
    {
        foreach (var agent in agents)
        {
            agent.space = motion;
            agent.ForceDecomposition();
        }
        
    }
}
