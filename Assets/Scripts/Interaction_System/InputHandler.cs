using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VHS
{
    public class InputHandler : MonoBehaviour
    {
        public InputTester inputTester;
        #region Data
            //[BoxGroup("Input Data")]
            //public CameraInputData cameraInputData;
            //[Boxgroup("Input Data")]
            //public MovementInputData movementInputData;
            //[BoxGroup("Input Data")]
            public InteractionInputData interactionInputData;

        #endregion


        #region BuiltIn Methods
        void Start()
        {
            //cameraInputData.ResetInput();
            //movementInputData.ResetInput();
            interactionInputData.ResetInput();
        }

        private void Update()
        {
            //GetCameraInput();
            //GetMovementInputData();
            GetInteractionInputData();
        }
        #endregion

        #region Custom Methods

        void GetInteractionInputData()
        {
            
            interactionInputData.InteractedClicked = Input.GetKeyDown(KeyCode.E);
            interactionInputData.InteractedRelease = Input.GetKeyUp(KeyCode.E);
            
            interactionInputData.InteractedClicked = inputTester.isPressed;
            //interactionInputData.InteractedRelease = !inputTester.isPressed;
        }
        
        void GetInteractionInputDataVR()
        {
            
            interactionInputData.InteractedClicked = inputTester.isPressed;
            interactionInputData.InteractedRelease = inputTester.isPressed;
        }

        #endregion
    }


}
