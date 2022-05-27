using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// need System.IO for reading and writing data files
using System.IO;

public class ColliderScript : MonoBehaviour
{
    //timer for each area
    private float timer1 = 0;
    private float timer2 = 0;
    private float timer3 = 0;
    private float timer4 = 0;
    private float timerOther = 0;

    //total time for each area (will be written to data output file
    private float area1_totalTime = 0;
    private float area2_totalTime = 0;
    private float area3_totalTime = 0;
    private float area4_totalTime = 0;
    private float areaOther_totalTime = 0;

    //data variables to write to data file
    private float data_out;

    private void Update()
    {
        //Only used to test if timers were working, can be deleted later
        Debug.Log(area1_totalTime);
    }
    private void OnTriggerEnter(Collider other)
    //when player enters each area (collides with area collision box), the time is recorded
    {
        switch (other.name)
        {
            case "Area_1":
                timer1 = Time.realtimeSinceStartup;
                break;
            case "Area_2":
                timer2 = Time.realtimeSinceStartup;
                break;
            case "Area_3":
                timer3 = Time.realtimeSinceStartup;
                break;
            case "Area_4":
                timer4 = Time.realtimeSinceStartup;
                break;
            default:
                timerOther = Time.realtimeSinceStartup;
                break;
        }
   }

   private void OnTriggerExit(Collider other)
   //then when the player leaves the area (exits collision box), the time spent is added to their total time in that area
   {
        switch (other.name)
        {
            case "Area_1":
                area1_totalTime += (Time.realtimeSinceStartup - timer1);
                updateData("time_1", area1_totalTime);
                break;
            case "Area_2":
                area2_totalTime += (Time.realtimeSinceStartup - timer2);
                updateData("time_2", area2_totalTime);
                break;
            case "Area_3":
                area3_totalTime += (Time.realtimeSinceStartup - timer3);
                updateData("time_3", area3_totalTime);
                break;
            case "Area_4":
                area4_totalTime += (Time.realtimeSinceStartup - timer4);
                updateData("time_4", area4_totalTime);
                break;
            default:
                areaOther_totalTime += (Time.realtimeSinceStartup - timerOther);
                updateData("time_Other", areaOther_totalTime);
                break;
        }
    }

        //write text file code copied from Unity support lol
        // https://support.unity.com/hc/en-us/articles/115000341143-How-do-I-read-and-write-data-from-a-text-file-
        public static void updateData(string heading, float data_out)
        {
            string path = "Assets/Resources/test.txt";

            //Write some text to the test.txt file
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(heading + "," + data_out);
            writer.Close();
        }
 

}
