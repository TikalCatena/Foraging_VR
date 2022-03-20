using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace VHS
{

    
    public class TimerMods : MonoBehaviour
        {
        public float[] timerMods = { 0, 0, 0, 1 };
        // Start is called before the first frame update
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
    }
}