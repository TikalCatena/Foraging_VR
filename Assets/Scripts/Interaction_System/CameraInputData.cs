using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VHS
{
    [CreateAssetMenu(fileName = "CameraInputData", menuName = "InteractionSystem/Inputdata")]
    public class CameraInputData : ScriptableObject
    {
        private bool m_interactedClicked;

        private bool m_interactedRelease;

        public bool InteractedClicked
        {
            get => m_interactedClicked;
            set => m_interactedClicked = value;
        }

        public bool InteractedRelease
        {
            get => m_interactedRelease;
            set => m_interactedRelease = value;
        }

        public void ResetInput()
        {
            m_interactedClicked = false;
            m_interactedRelease = false;
        }
    }
}