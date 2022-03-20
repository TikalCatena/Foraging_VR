using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    [SerializeField] private float _turnspeed = 5f;

    private void Update()
    {
        var horizontal = Input.GetAxis("Mouse X");
        transform.Rotate(horizontal * _turnspeed * Vector3.up, Space.Self);

    }
}
