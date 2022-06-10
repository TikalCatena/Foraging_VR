using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// need System.IO for reading and writing data files
using System.IO;

namespace VHS
{
    public class ColliderScript : MonoBehaviour
    {
        [SerializeField] InteractionUIPanel uiPanel;

        [Space, Header("Test file?")]
        public bool testfile;


        //location marker
        public string location = "";

        //timers for each area
        private float area0_timeSpent = 0;
        private float area1_timeSpent = 0;
        private float area2_timeSpent = 0;
        private float area3_timeSpent = 0;

        private float timer0 = 0;
        private float timer1 = 0;
        private float timer2 = 0;
        private float timer3 = 0;
        private float timerOther = 0;

        //total time for each area (will be written to data output file

        private float area0_totalTime = 0;
        private float area1_totalTime = 0;
        private float area2_totalTime = 0;
        private float area3_totalTime = 0;
        private float areaOther_totalTime = 0;

        //data variables to write to data file
        private float data_out;

        private void Update()
        {

        }
        private void OnTriggerEnter(Collider other)
        //when player enters each area (collides with area collision box), the time is recorded
        {
            location = other.name;
            switch (other.name)
            {
                case "Area_0":
                    timer0 = Time.realtimeSinceStartup;
                    break;
                case "Area_1":
                    timer1 = Time.realtimeSinceStartup;
                    break;
                case "Area_2":
                    timer2 = Time.realtimeSinceStartup;
                    break;
                case "Area_3":
                    timer3 = Time.realtimeSinceStartup;
                    break;
                default:
                    timerOther = Time.realtimeSinceStartup;
                    break;
            }
        }

        private void OnTriggerExit(Collider other)
        //then when the player leaves the area (exits collision box), the time spent is added to their total time in that area
        {
            location = "";
            switch (other.name)
            {
                case "Area_0":
                    area0_timeSpent = Time.realtimeSinceStartup - timer0;
                    area0_totalTime += (Time.realtimeSinceStartup - timer0);
                    updateData("time_0", area0_totalTime, testfile);
                    break;
                case "Area_1":
                    area1_timeSpent = Time.realtimeSinceStartup - timer1;
                    area1_totalTime += (Time.realtimeSinceStartup - timer1);
                    updateData("time_1", area1_totalTime, testfile);
                    break;
                case "Area_2":
                    area2_timeSpent = Time.realtimeSinceStartup - timer2;
                    area2_totalTime += (Time.realtimeSinceStartup - timer2);
                    updateData("time_2", area2_totalTime, testfile);
                    break;
                case "Area_3":
                    area3_timeSpent = Time.realtimeSinceStartup - timer3;
                    area3_totalTime += (Time.realtimeSinceStartup - timer3);
                    updateData("time_3", area3_totalTime, testfile);
                    break;
                
                default:
                    areaOther_totalTime += (Time.realtimeSinceStartup - timerOther);
                    updateData("time_Other", areaOther_totalTime, testfile);
                    break;
            }
        }

        //write text file code copied from Unity support lol
        // https://support.unity.com/hc/en-us/articles/115000341143-How-do-I-read-and-write-data-from-a-text-file-
        public static void updateData(string heading, float data_out, bool testfile)
        {
            string testpath = "Assets/Resources/test.txt";
            string path = "Assets/Resources/";
            string path2 = string.Format("{0}{1:hh_mm}.txt", path, System.DateTime.Now);

            if (testfile)
            {
                path2 = testpath;
            }

            //Write some text to the test.txt file

            StreamWriter writer = new StreamWriter(path2, true);
            writer.WriteLine(heading + "," + data_out);
            writer.Close();
        }

    public string GetLocation()
        {
            //return location.Substring(location.Length - 5);
            return location;
        }
    }
}