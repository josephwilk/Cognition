using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class arduinoInput: MonoBehaviour
{
    Joystick joystick;
    //Controls controls;
    float value = 0;
    // Start is called before the first frame update
    void Start()
    {
        joystick = Joystick.current;


        //controls = new Controls();

        //// controls.actionmap.joystick.performed += ctr => value = ctr.ReadValue<float>();
        //controls.actionmap.joystick.performed += ctr => performed();
    }

    //void performed() {
    //    Debug.Log("performed...");
    //}

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(value);
        if (joystick != null)
        {
            Debug.Log(joystick.stick.x.ReadValue() + ", " + -joystick.stick.y.ReadValue());
        }
    }
}
