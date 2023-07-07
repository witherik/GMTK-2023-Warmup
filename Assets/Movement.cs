using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float moveSpeed = 5.0f;

    private Vector3 inputVector;

    void Update()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        inputVector = Vector3.ClampMagnitude(inputVector, 1);

    }
    void FixedUpdate()
    {
        Vector3 moveForce = inputVector * moveSpeed * Time.fixedDeltaTime;
        _rigidbody.AddForce(moveForce);
    }
}
