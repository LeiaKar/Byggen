using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput), typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
public class LimitedPlatformerMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float jumpForce = 10f;
    
    private Vector2 moveInput;
    private bool jumpInput;
    
    private Rigidbody2D rb;
    private CapsuleCollider2D groundCheckCollider; 

    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheckCollider = GetComponent<CapsuleCollider2D>();
    }
    
    void Update()
    {
        // Apply horizontal velocity from input
        rb.linearVelocityX = moveInput.x * maxSpeed;
        
        // Apply vertical velocity from jump
        if (jumpInput && IsGrounded())
        {
            rb.linearVelocityY = jumpForce;
        }
        jumpInput = false; // only jump once for each press of the jump-button
    }

    private bool IsGrounded()
    {
        // Is our groundCheckCollider touching the groundLayer? If so, return the value "true"
        if (groundCheckCollider.IsTouchingLayers(~0)) // ~0 is referring to EVERY layer.
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
    }
    
    public void OnJump(InputValue input)
    {
        jumpInput = true;
    }
}