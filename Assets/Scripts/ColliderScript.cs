using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
   private float timer = 0 ; 
   private void OnTriggerEnter(Collider other)
   {
   	Debug.Log(other.name);
      if(other.name == "Area_4")
         timer = Time.realtimeSinceStartup; 
   }

   private void OnTriggerExit(Collider other)
   {
      if(other.name == "Area_4") 
         Debug.Log(Time.realtimeSinceStartup - timer); 
   }
}
