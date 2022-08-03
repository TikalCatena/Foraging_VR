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

        public bool buffer = true;

        private void Start()
        {
        } //Monobehaviours without a Start function cannot be disabled in Editor, just FYI

        private void OnEnable()
        {
            TriggerClick.AddOnStateDownListener(Press, inputSource);
            print("down");
        }

        private void OnDisable()
        {
            TriggerClick.RemoveOnStateDownListener(Press, inputSource);
            print("up");
        }

        private void Press(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {
            //put your stuff here
            print("Success");
            //interactionController.m_interacting = true;
            isPressed = true;

        }

        private void Update()
        {
            if (buffer)
            {
                buffer = false;
            }
            else
            {
                isPressed = false;
                buffer = true;
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