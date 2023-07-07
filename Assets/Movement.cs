using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float accel = 25.0f;
    [SerializeField] private float drag = 10.0f;
    private Vector3 inputVector;
    private Vector3 lastVel;

    void Update()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        inputVector = Vector3.ClampMagnitude(inputVector, 1);

    }
    void FixedUpdate()
    {
        Vector3 desiredVel = inputVector * moveSpeed;

        Vector3 newVel = Vector3.MoveTowards(lastVel, Vector3.zero, drag * Time.fixedDeltaTime);
        if (desiredVel != Vector3.zero)
        {
            newVel = Vector3.MoveTowards(newVel, desiredVel, accel * Time.fixedDeltaTime);
        }
        newVel.y = _rigidbody.velocity.y;
        Vector3 moveVelocity = newVel;
        _rigidbody.velocity = moveVelocity;
        lastVel = _rigidbody.velocity;
        lastVel.y = 0;
    }
}
