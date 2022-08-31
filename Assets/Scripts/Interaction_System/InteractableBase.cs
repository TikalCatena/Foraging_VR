using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VHS
{
    public class InteractableBase : MonoBehaviour, IInteractable
    {
        #region Variables
        [Header("Interactable Settings")]

        [SerializeField] private float holdDuration;

        [Space]

        [SerializeField] private bool holdInteract;

        [SerializeField] private bool multipleUse;

        [SerializeField] private bool isInteractable;

        [SerializeField] public string tooltipMessage;

        #endregion

        #region Properties
        public float HoldDuration => holdDuration;

        public bool HoldInteract => holdInteract;

        public bool MultipleUse => multipleUse;

        public bool IsInteractable => isInteractable;

        public string TooltipMessage => tooltipMessage;

        #endregion

        #region Methods

        public virtual void OnInteract()
        {
            Debug.Log("Interacted: " + gameObject.name);
        }

        #endregion
    }
}