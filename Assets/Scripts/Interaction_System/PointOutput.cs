using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
//using Random = UnityEngine.Random;


namespace VHS
{
    public class PointOutput : InteractableBase
    {
        [SerializeField] InteractionUIPanel uiPanel;
        [SerializeField] TimerMods timerMods;
        [SerializeField] ColliderScript colliderScript;
        [SerializeField] private bool setRefreshTime;
        [SerializeField] private float refreshTime;
        [SerializeField] private float refreshRadius;
        [SerializeField] private float point1Delta = 1;
        [SerializeField] private int sourceId;
        private bool pointsAvailable;
        private float timer = 2;

        //Hover Tooltip
        //public string tooltipMessage_true;
        //private string TooltipMessage;

        // TODO: Switch randomization system to UnityEngine.Random.
        System.Random rnd = new System.Random();

        private int _id => sourceId;

        public float timerMod => timerMods.getTimerMod(_id);

        [SerializeField] private string area;
        public string _area => area;


        //private int timerMod;
        //int id = sourceId;


        public void Start()
        {
                // ** Randomize trial order **
            /*Random.InitState(subjectNumber * 10); // Insures same path randomizations every run for same subject (in case the experiment needs restarted)
            //trialOrder = new int[trialList.Length];
            //for(int i=0; i<trialOrder.Length; i++)
            //    trialOrder[i] = i;
            //for(int t=number_practice_trials; t<trialOrder.Length; t++)
            //{
                int tmp = trialOrder[t];
                int r = Random.Range(t, trialOrder.Length);
                trialOrder[t] = trialOrder[r];
                trialOrder[r] = tmp;
            } */
                //float[] typeDistShuffle = timerMods.OrderBy(x => rnd.Next()).ToArray();
               // timer = 10;
               // timerMod = typeDistShuffle[sourceId];

        
        }

       
        public override void OnInteract()
            {

                

                if (pointsAvailable)
                {
                    uiPanel.TempMessage("You got 1 point!", "green");


                    uiPanel.Point1Update(point1Delta);

                    timer = refreshTime * timerMod;
                }
                else
                {
                    uiPanel.TempMessage("There's nothing to collect!", "warning");

                    Debug.Log("Time remaining: " + timer);
                    Debug.Log("Timer modifier: " + timerMod);
                }
            }

        private void Update()
        {
            //checking whether enough time has passed to reset resources
            checkTimer();

            
            
            //checking whether agent is in the right area to interact with source

            if(colliderScript.GetLocation() == "")
            {
                uiPanel.SetTooltip("");
            }
        }

        

        void checkTimer()
        {
            if (timer>0)
            {
                timer -= Time.deltaTime;
                pointsAvailable = false;
            }

            if (timer <= 0)
            {
                pointsAvailable = true;
            }
        }
    }
}