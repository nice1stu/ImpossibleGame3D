using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isGrounded = true;

    private Rigidbody _rb;
    private bool _isJumping;
    private Quaternion _targetRotation;
    private Quaternion _startRotation;
    private const float RotationDuration = 1.2f;
    private float _rotationTimer;
    private bool _rotating;

    private readonly float _jumpForce = 7f;
    private readonly float _fallingForce = -15f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_rb.linearVelocity.y < -0.1f)
            _rb.AddForce(0, _fallingForce, 0);

        if (_rotating)
        {
            _rotationTimer += Time.fixedDeltaTime;
            float t = Mathf.Clamp01(_rotationTimer / RotationDuration);
            transform.rotation = Quaternion.Slerp(_startRotation, _targetRotation, t);

            if (t >= 1f) _rotating = false;
        }
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out _, 1.5f);

        if (isGrounded && Input.GetButtonDown("Jump") && !_isJumping)
        {
            _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, _jumpForce, _rb.linearVelocity.z);
            _isJumping = true;
            _rotating = true;
            _startRotation = transform.rotation;
            _targetRotation = _startRotation * Quaternion.Euler(-180f, 0f, 0f);
            _rotationTimer = 0f;
        }
        if (_isJumping && isGrounded) _isJumping = false;
    }
}