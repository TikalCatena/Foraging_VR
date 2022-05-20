using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
    
{
    public float speed = 10.0f;

    void Update()
    {
        if (Input.GetAxis("Mouse X") > 0)
        {
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                0.0f, Mathf.Clamp(Input.GetAxisRaw("Mouse Y"), -45, 45) * Time.deltaTime * speed);
        }

        else if (Input.GetAxis("Mouse X") < 0)
        {
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                0.0f, Mathf.Clamp(Input.GetAxisRaw("Mouse Y"), -45, 45) * Time.deltaTime * speed);
        }
          
    }
}
