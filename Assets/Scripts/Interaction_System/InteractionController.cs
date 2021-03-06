using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VHS
{
    // Start is called before the first frame update
    public class InteractionController : MonoBehaviour
    {

        #region Variables

        [Header("Data")]

        public InteractionInputData interactionInputData;
        public InteractionData interactionData;

        [Space, Header("UI")]
        [SerializeField] private InteractionUIPanel uiPanel;

        [Space]
        [Header("Ray Settings")]

        public float rayDistance;

        public float raySphereRadius;

        public LayerMask interactableLayer;

        #region Private

            private Camera m_cam;
        private bool m_interacting;
        private float m_holdTimer = 0f;
        #endregion
        #endregion

        #region Built In Methods

        void Awake()
        {
            m_cam = FindObjectOfType<Camera>();
        }

        void Update()
        {
            CheckForInteractable();
            CheckForInteractableInput();
        }

        #endregion

        #region Custom Methods
        void CheckForInteractable()
        {
            Ray _ray = new Ray(m_cam.transform.position, m_cam.transform.forward);
            RaycastHit _hitInfo;

            bool _hitSomething = Physics.SphereCast(_ray, raySphereRadius, out _hitInfo, rayDistance, interactableLayer);

            if(_hitSomething)
            {
                InteractableBase _interactable = _hitInfo.transform.GetComponent<InteractableBase>();

                if(_interactable != null)
                {
                    if (interactionData.IsEmpty())
                    {
                        interactionData.Interactable = _interactable;
                        uiPanel.SetTooltip(_interactable.TooltipMessage); // Interaction message!
                    }
                    else
                    {
                        if (!interactionData.IsSameInteractable(_interactable))
                        {
                            interactionData.Interactable = _interactable;
                            uiPanel.SetTooltip(_interactable.TooltipMessage);
                        }
                    }    
                }
                
            }
            else
            {
                uiPanel.ResetUI();
                interactionData.ResetData();
            }

            Debug.DrawRay(_ray.origin, _ray.direction * rayDistance, _hitSomething ? Color.green : Color.red);
        }

        void CheckForInteractableInput()
        {
            if (interactionData.IsEmpty())
            {
                return;
            }
            if(interactionInputData.InteractedClicked)
            {
                m_interacting = true;
                m_holdTimer = 0f;
            }

            if (interactionInputData.InteractedRelease)
            {
                m_interacting = false;
                m_holdTimer = 0f;
                uiPanel.UpdateProgressBar(0f);
            }

            if (m_interacting)
            {
                if (!interactionData.Interactable.IsInteractable)
                {
                    return;
                }
                if (interactionData.Interactable.HoldInteract)
                {
                    m_holdTimer += Time.deltaTime;

                    float _heldPercent = m_holdTimer / interactionData.Interactable.HoldDuration;

                    uiPanel.UpdateProgressBar(_heldPercent);

                    if (_heldPercent >= 1)
                    {
                        interactionData.Interact();
                        m_interacting = false;
                    }
                }
                else
                {
                    interactionData.Interact();
                    m_interacting = false;
                }
            }
        }

        #endregion
    }
}
