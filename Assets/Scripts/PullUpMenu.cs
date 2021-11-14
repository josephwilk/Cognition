using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PullUpMenu : MonoBehaviour
{
    public SteamVR_Action_Boolean MenuOnOff;

    public SteamVR_Input_Sources handType;

    public GameObject panel;

    public GameObject controllerMesh;

    // Start is called before the first frame update
    void Start()
    {
        MenuOnOff.AddOnStateDownListener(TriggerDown, handType);
        MenuOnOff.AddOnStateUpListener(TriggerUp, handType);
    }
    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //Debug.Log(“Trigger is up”);
        //panel.SetActive(false);
    }
    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //Debug.Log(“Trigger is down”);
        panel.SetActive(true);
        controllerMesh.SetActive(true);
    }

}
