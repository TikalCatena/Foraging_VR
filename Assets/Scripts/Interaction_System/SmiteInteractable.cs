using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VHS
{
    public class SmiteInteractable : InteractableBase
    {
        [SerializeField] private float sins = 1000;
        [SerializeField] InteractionUIPanel uiPanel;
        public override void OnInteract()
        {
            Rigidbody m_rigidbody;

            m_rigidbody = gameObject.GetComponent<Rigidbody>();

            uiPanel.TempMessage("That'll show it");

            m_rigidbody.AddForce(Vector3.up * sins );

        }
    }
}