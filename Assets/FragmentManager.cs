using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentManager : MonoBehaviour
{

    private FractureMover[] movers;

    [Range(0.00f, 0.09f)]
    public float motion = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        FractureMover[] movers = GetComponentsInChildren<FractureMover>();
        

    }

    // Update is called once per frame
    void Update()
    {
        foreach (var m in movers)
        {
            m.space = motion;
        }
        
    }
}
