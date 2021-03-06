using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float _MoveSpeed = 10f;

    CharacterController _characterController;
    public bool IsGrounded;

    void Awake() => _characterController = GetComponent<CharacterController>();
    

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        Vector3 movement = transform.TransformDirection(direction) * _MoveSpeed;
        IsGrounded = _characterController.SimpleMove(movement);
    }
}
