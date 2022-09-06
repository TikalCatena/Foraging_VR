using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VHS
{
    public class InputHandler : MonoBehaviour
    {
        //public InputTester inputTester;
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

        float inputTimer = 0f;
        public bool GetTrigger()
        {
            if (Time.realtimeSinceStartup - inputTimer > 0.5f & SteamControllerVR.Instance.triggerPressed )
            {
                inputTimer = Time.realtimeSinceStartup;
				//print("Trigger got");
                return true;
            }
            return false;


        }
        void GetInteractionInputData()
        {
            
            //interactionInputData.InteractedClicked = Input.GetKeyDown(KeyCode.E);
            //interactionInputData.InteractedRelease = Input.GetKeyUp(KeyCode.E);
            

            interactionInputData.InteractedClicked = GetTrigger();
            //interactionInputData.InteractedRelease = !GetTrigger();
        }
        
        
        #endregion
    }


}
