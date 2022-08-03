using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace Valve.VR
{
    public class ViveInput : MonoBehaviour
    {
        public SteamVR_TrackedObject MTrackedObject = null;

        //public SteamVR_Controller.device mDevice;
        // Start is called before the first frame update
        void awake()
        {
            MTrackedObject = GetComponent<SteamVR_TrackedObject>();
        }

        // Update is called once per frame
        void Update()
        {
            //mDevice = SteamVR_Controller.Input((int) mTrackedObject.index);
        
            #region Trigger

            //if (mDevice.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("Trigger down");
            }
        
            //if (mDevice.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("Trigger up");
            }
            #endregion
        
            //Vector2 triggerValue = mDevice.GetAxis(EVRButtonId.k_EButton_SteamVR.Trigger);
        }
    }

}
