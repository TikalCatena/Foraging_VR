using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace VHS
{



    public class PetInteractable : InteractableBase
    {
        [SerializeField] float petIntensity = 20f;
        [SerializeField] InteractionUIPanel uiPanel;
        public override void OnInteract()
        {
            Rigidbody m_rigidbody;

            m_rigidbody = gameObject.GetComponent<Rigidbody>();

            Debug.Log("You pet " + gameObject.name + "!");
            m_rigidbody.AddForce(Vector3.up * petIntensity);

            uiPanel.RandomText3("Yean!", "Nice!", "Wow!") ;

        }
    }
}