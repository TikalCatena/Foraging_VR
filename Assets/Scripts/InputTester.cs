using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace VHS
{


    public class InputTester : MonoBehaviour
    {
        public bool isPressed;
        public InteractionController interactionController;
        public SteamVR_Action_Boolean TriggerClick;
        private SteamVR_Input_Sources inputSource;
        private SteamControllerVR steamControllerVR;

        public bool buffer = true;
        float timer;

        private void Start()
        {
            timer = 0;
        } //Monobehaviours without a Start function cannot be disabled in Editor, just FYI

        public void OnEnable()
        {
            TriggerClick.AddOnStateDownListener(Press, inputSource);
            print("down");
        }

        public void OnDisable()
        {
            TriggerClick.RemoveOnStateDownListener(Press, inputSource);
            print("up");
        }
        private void Press(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {
            if (Time.realtimeSinceStartup - timer > .5f)
            {
                timer = Time.realtimeSinceStartup;
                print("Success");
            }
            else
            {
                print("too fast");
            }
            //put your stuff here
            
            interactionController.m_interacting = true;
            isPressed = true;

        }


        
        private void Update()
        {
            if (buffer)
            {
                //buffer = false;
            }
            else
            {
                //isPressed = false;
                //buffer = true;
            }
            //isPressed = false;
            //if(SteamVR_Input.__actions_default_in_GrabPinch.GetStateDown(inputSource))
            {
                //Debug.Log("Trigger was pressed");
            }
            
            //if(SteamVR_Input.__actions_default_in_GrabPinch.GetStateUp(inputSource))
            {
                //Debug.Log("Trigger depressed");
            }
        }
    }
    
}