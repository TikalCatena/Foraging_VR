using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
//using Unity.Mathematics;
//using Random = UnityEngine.Random;


namespace VHS
{
    public class PointOutput : InteractableBase
    {
        [SerializeField] InteractionUIPanel uiPanel;
        [SerializeField] TimerMods timerMods;
        [SerializeField] ColliderScript colliderScript;
		[SerializeField] InteractionController interactionController;
        [SerializeField] private bool setRefreshTime;
        [SerializeField] private float refreshTime;
        [SerializeField] private float refreshRadius;
        [SerializeField] private float point1Delta = 1;
        [SerializeField] private int sourceId;
        [SerializeField] private int lightIntensity = 2;


        //[SerializeField] LightingSwitch localLight; 
        private bool pointsAvailable;
        private float timer = 5;
        public Light thislight; //get the point light to modify intensity
		public GameObject thiscrystal; //get the crystal to modify material emissions
        public static float gotPoint;
        float timerMean => timerMods.getTimerMean();
        float timerSD => timerMods.getTimerSD();
        float localOdds => timerMods.getOdds(sourceId);
		private string _baseTooltip;
		

        //Hover Tooltip
        //public string tooltipMessage_true;
        //private string TooltipMessage;

        // TODO: Switch randomization system to UnityEngine.Random.
        System.Random rnd = new System.Random();

        private int _id => sourceId;

        public float timerMod => timerMods.getTimerMean();

        [SerializeField] private string area;
        public string _area => area;


        //private int timerMod;
        //int id = sourceId;

        [SerializeField] private Material crystalMaterial;
        [SerializeField] private Renderer objectToChange;

        //sound effects
        public AudioSource harvestSound;
        public AudioSource emptySound;

        public void Start()
        {
            //create an instance of the emissive material to modify if you want to change individual objects materials instead of for all obj with that material
            //crystalMaterial = objectToChange.GetComponent<Renderer>().material;

            _baseTooltip = TooltipMessage;
            // SELECT LIGHT TO BE MANIPULATED
            //GameObject localLight = GameObject.Find("Point_light_0");
            //Light thislight = localLight.GetComponent<Light>();
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

            Debug.Log("Interacted: " + gameObject.name);
            //Debug.Log("This light: " + localLight.name);

            if (pointsAvailable)
                {
                    float pull = Random.Range(0f, 1f);
                Debug.Log(pull);
                Debug.Log(localOdds);

                if (pull < localOdds)
                {
                    uiPanel.TempMessage("You got 1 point!", "green");

                    //HERE PULL MODIFIER FROM RANDOM DISTRIBUTION, REPLACE TIMERMOD WITH THIS [not sure this is still relevant]
                    uiPanel.Point1Update(point1Delta);
                    gotPoint = 1f;

                    harvestSound.Play();
                }
                else
                {
                    uiPanel.TempMessage("No points received", "warning");
					uiPanel.Point1Update(0);
                    gotPoint = 0f;

                    emptySound.Play();
                }    

                    // Original Timer
                    timer = timerMean;

                ColliderScript.updateData_2(_id.ToString(), localOdds, gotPoint, false);

                // New (normally distributed) timer

                //timer = generateNormal(timerMean, timerSD);
                }
                else
                {
                    uiPanel.TempMessage2("There's nothing to collect!", "warning");

                    Debug.Log("Time remaining: " + timer);
                    //Debug.Log("Timer modifier: " + timerMod);
                }
			//interactionController.m_interacting = false;
            }

        private void Update()
        {
            //checking whether enough time has passed to reset resources
            checkTimer();
			if (pointsAvailable) 
			{
				tooltipMessage = _baseTooltip;
			} 
			else 
			{
				tooltipMessage = "";
			}

            
            
            //checking whether agent is in the right area to interact with source

            //if(colliderScript.GetLocation() == ""){uiPanel.SetTooltip("");}
        }

        

        void checkTimer()
        {
            if (timer>0)
            {
                timer -= Time.deltaTime;
                pointsAvailable = false;

                //attempting to make material emission increase with timer

                crystalMaterial.SetFloat("_EmissionPower", (20f * ((timerMean - timer) / timerMean) * ((timerMean - timer) / timerMean) * ((timerMean - timer) / timerMean)) + .2f);
               
                //Light proportional to timer progress

                thislight.intensity = (lightIntensity * ((timerMean - timer)/timerMean) * ((timerMean - timer)/timerMean) * ((timerMean - timer)/timerMean));
            }

            if (timer <= 0)
            {
                pointsAvailable = true;
                thislight.intensity = lightIntensity;
            }
        }

        public static float generateNormal(float mean, float sd)
        {
            float v1, v2, s;
            float range = 3.5f;
            float min = mean - (range * sd);
            float max = mean + (range * sd);

            v1 = 2.0f * Random.Range(0f, 1f) - 1.0f;
            v2 = 2.0f * Random.Range(0f, 1f) - 1.0f;
            s = v1 * v1 + v2 * v2;

            do
            {
                v1 = 2.0f * Random.Range(0f, 1f) - 1.0f;
                v2 = 2.0f * Random.Range(0f, 1f) - 1.0f;
                s = v1 * v1 + v2 * v2;
            } while (s >= 1.0f || s == 0f);


            s = Mathf.Sqrt((-2.0f * Mathf.Log(s)) / s);


            float g = s * sd + mean;

            Debug.Log("Normal generated (unscaled) = " + s);
            Debug.Log("Normal generated (scaled) = " + g);

            return g;
        }
    }
}