using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;


namespace VHS
{
    public class PointOutput : InteractableBase
    {
        [SerializeField] InteractionUIPanel uiPanel;
        [SerializeField] TimerMods timerMods;
        [SerializeField] private bool setRefreshTime;
        [SerializeField] private float refreshTime;
        [SerializeField] private float refreshRadius;
        [SerializeField] private float point1Delta = 1;
        [SerializeField] private int sourceId;
        private bool pointsAvailable;
        private float timer = 10;
        System.Random rnd = new System.Random();
        private int timerMod;
        //int id = sourceId;
        
        

        public void Start()
        {
            //float[] typeDistShuffle = timerMods.OrderBy(x => rnd.Next()).ToArray();
            timer = 10;
            //timerMod = typeDistShuffle[sourceId];
            float timerMod = timerMods.getTimerMod(sourceId);

        }
        public override void OnInteract()
        {
            

            if (pointsAvailable)
            {
                uiPanel.TempMessage("You got 1 point!", "green");


                uiPanel.Point1Update(point1Delta);

                timer = refreshTime*timerMod;
            }
            else
            {
                uiPanel.TempMessage("There's nothing to collect!", "warning");
            }
            


        }

        private void Update()
        {
            checkTimer();
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