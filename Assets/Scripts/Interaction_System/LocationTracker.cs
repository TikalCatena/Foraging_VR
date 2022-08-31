using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
 
public class LocationTracker : MonoBehaviour
{
    string filename = "";

    public GameObject vrcam;
    public StreamWriter writer;

    Vector3 position;
    Quaternion orientation;

    private int currentFrame = 0;
    [SerializeField]
    private int trackerResolution = 30;

    public bool createdTrackData = false;

    // Start is called before the first frame update
    void Start()
{
      filename = Application.dataPath + "/" + ReadInput.participantID + "test.csv";


}



// Update is called once per frame
void Update()
{


        if (currentFrame > trackerResolution) 
        {
            WriteData();
            currentFrame = 0;
        }

        currentFrame += 1;

}
 
public void WriteData() 
    {
        if (!createdTrackData)
        {
            using (TextWriter tw = File.CreateText(filename))
            {
                tw.WriteLine("PosX,"+"PosY,"+"PosZ," + "Q1,"+"Q2,"+"Q3,"+"Q4,");
            }
            createdTrackData = true;
        }
        else
        {
            //get vector3 of XRrig or camera position (x,y,z) and quaternion of rotation
            position = vrcam.transform.position;
            orientation = vrcam.transform.rotation;

            //remove () for the csv
            string pos = position.ToString().Replace("(", "").Replace(")", "");
            string ori = orientation.ToString().Replace("(", "").Replace(")", ""); 

            using (TextWriter tw = File.AppendText(filename))
            {
                tw.WriteLine(pos + "," + ori + "," + Time.realtimeSinceStartup + ",");
                tw.Close();
            }


        }
     }
}