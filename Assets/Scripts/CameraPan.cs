using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{

    [SerializeField] private float _turnspeed = 5f;
    private void Update()
    {
        

        var vertical = Input.GetAxis("Mouse Y");
        transform.Rotate(vertical * _turnspeed * Vector3.left, Space.Self);
    }
}
