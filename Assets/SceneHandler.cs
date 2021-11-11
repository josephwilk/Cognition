/* SceneHandler.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;
using UnityEngine.Playables;


namespace PathCreation.Examples
{
    public class SceneHandler : MonoBehaviour
    {
        public SteamVR_LaserPointer laserPointer;

        public PlayableDirector director;
        public PathFollower pathFollower;
        public dimLights dimLights;

        public GameObject panel;

        public GameObject controllerMesh;

        public GameObject[] toDisable;
        

        


        void Awake()
        {
            laserPointer.PointerIn += PointerInside;
            laserPointer.PointerOut += PointerOutside;
            laserPointer.PointerClick += PointerClick;
        }

        public void PointerClick(object sender, PointerEventArgs e)
        {
            if (e.target.name == "ButtonRestart")
            {
                Debug.Log("Restarting");

                director.Stop();
                director.time = 0;

                dimLights.setDimValue(0);

                pathFollower.resetProgress();

                panel.SetActive(false);

                controllerMesh.SetActive(false);

                foreach(GameObject x in toDisable)
                {
                    x.SetActive(false);
                }
            }
            else if (e.target.name == "ButtonClose")
            {
                //Debug.Log("Button was clicked");

                panel.SetActive(false);

                controllerMesh.SetActive(false);
            }
        }

        public void PointerInside(object sender, PointerEventArgs e)
        {
            if (e.target.name == "Cube")
            {
                //Debug.Log("Cube was entered");
            }
            else if (e.target.name == "Button")
            {
                //Debug.Log("Button was entered");
            }
        }

        public void PointerOutside(object sender, PointerEventArgs e)
        {
            if (e.target.name == "Cube")
            {
                //Debug.Log("Cube was exited");
            }
            else if (e.target.name == "Button")
            {
                //Debug.Log("Button was exited");
            }
        }
    }
}