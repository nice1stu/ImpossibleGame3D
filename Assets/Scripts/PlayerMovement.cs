using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isGrounded = true;
    
    private Rigidbody _rb;
    
    private readonly float _jumpForce = 7f;
    private readonly float _fallingForce = -15f;
    private readonly float _rotationSpeed = 15f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_rb.velocity.y < -0.1f)
            _rb.AddForce(0,_fallingForce,0);
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out _, 1.5f);

        switch (isGrounded)
        {
            case true when Input.GetButtonDown("Jump"):
                _rb.velocity = new Vector3(0, _jumpForce, 0);
                break;
            case false:
            {
                float desiredAngularVelocity = _rotationSpeed * Mathf.PI / 180f;
                _rb.AddTorque(transform.right * desiredAngularVelocity);
                break;
            }
        }
    }
}