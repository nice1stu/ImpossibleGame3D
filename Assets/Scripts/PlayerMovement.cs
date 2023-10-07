using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isGrounded = true;
    
    private Rigidbody rb;
    private float tileSpacing = 1f;
    private float jumpForce = 7f;
    private float jumpStartTime;
    private float rotationSpeed = 140f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
            isGrounded = true;
        else
            isGrounded = false;

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(0, jumpForce, 0);
            jumpStartTime = Time.time;
        }
        
        float rotationProgress = (Time.time - jumpStartTime) / rotationSpeed;
        
        if (!isGrounded && rotationProgress < 1f)
        {
            rb.rotation = Quaternion.Euler(rotationProgress * 90, 0, 0) * rb.rotation;
        }
    }
}