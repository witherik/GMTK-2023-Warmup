using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float accel = 25.0f;
    [SerializeField] private float drag = 10.0f;
    private Vector3 _inputVector;
    private Vector3 _lastVel;

    private void Update() {
        _inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        _inputVector = Vector3.ClampMagnitude(_inputVector, 1);
    }

    private void FixedUpdate() {
        var desiredVel = _inputVector * moveSpeed;

        var newVel = Vector3.MoveTowards(_lastVel, Vector3.zero, drag * Time.fixedDeltaTime);
        if (desiredVel != Vector3.zero) {
            newVel = Vector3.MoveTowards(newVel, desiredVel, accel * Time.fixedDeltaTime);
        }

        var rigidBodyVelocity = rigidBody.velocity;
        newVel.y = rigidBodyVelocity.y;
        var moveVelocity = newVel;
        rigidBody.velocity = moveVelocity;
        _lastVel = rigidBodyVelocity;
        _lastVel.y = 0;
    }

    void RotateToVelocity()
    {
        var vel = rigidBody.velocity;
        vel.y = 0;
        // transform.localRotation = Vector3.RotateTowards()
    }
}