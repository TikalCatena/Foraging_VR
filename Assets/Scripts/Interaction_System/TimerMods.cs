using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace VHS
{

    
    public class TimerMods : MonoBehaviour
        {

        [SerializeField] public float timerMean;
        [SerializeField] public float timerSD;
        public float[] timerMods = { 0, 1, 2, 3 };
        
        System.Random rnd = new System.Random();
        private float[] typeDistShuffle;
        

        public void Start()
        {
            typeDistShuffle = timerMods.OrderBy(x => rnd.Next()).ToArray();
        }

        public float getTimerMod(int x)
        {
            return typeDistShuffle[x];
        }

        public float getTimerMean()
        {
            return timerMean;
        }

        public float getTimerSD()
        {
            return timerSD;
        }
    }
}