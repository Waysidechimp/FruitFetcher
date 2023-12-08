using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    Rigidbody2D rb;
    //General Movement
    bool isFacingRight = true;
    float moveValue = 0;
    float speed = 6;
    //Jumping
    float jumpGravity = 4;
    float fallGravity = 8;
    float jumpPower = 14;
    //Ground Check
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    //Coyote Time
    float coyoteTime = 0.1f;
    float coyoteTimeCounter;
    //Jump Buffer
    float jumpBufferTime = 0.2f;
    float jumpBufferCounter;
    //Animation
    [SerializeField] Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Flip();

        if (isGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        if(rb.velocity.y < -0.1f)
        {
            animator.SetBool("isFalling", true);
        }
        else
        {
            animator.SetBool("isFalling", false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveValue * speed, rb.velocity.y);
        if (rb.velocity.y <= 0)
        {
            rb.gravityScale = fallGravity;
        }
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        animator.SetBool("isRunning", true);
        moveValue = value.ReadValue<float>();
        if (value.canceled)
        {
            animator.SetBool("isRunning", false);
        }
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (jumpBufferCounter > 0 && coyoteTimeCounter > 0)
        {
            rb.gravityScale = jumpGravity;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);

            jumpBufferCounter = 0;
        }
        if(value.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }
    }

    public void OnEscape()
    {
        Application.Quit();
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void Flip()
    {
        if(isFacingRight && moveValue < 0f || !isFacingRight && moveValue > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
