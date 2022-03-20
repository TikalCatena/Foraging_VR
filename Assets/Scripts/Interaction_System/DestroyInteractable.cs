using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VHS
{
    public class DestroyInteractable : InteractableBase
    {
        // Start is called before the first frame update
        public override void OnInteract()
        {
            base.OnInteract(); // calls the original/base method (debug)

            Destroy(gameObject);

        }
    }
}