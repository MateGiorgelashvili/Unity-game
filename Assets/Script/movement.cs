using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float jumpForce = 3f;
    public Vector2 boxSize = new Vector2(1, 0.2f);
    public float castDistance = 1;
    public LayerMask groundLayer;
    private bool isFacingRight = true;
    Animator Anim;

    public int maxJumps = 2;
    public int jumpsLeft;

    bool isIdle = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        jumpsLeft = maxJumps;
    }

    void Update()
    {
        float movementInput = Input.GetAxisRaw("Horizontal");

        if (movementInput != 0)
        {
            Anim.Play("run");
            isIdle = false;
        }
        else if (isGrounded() && !isIdle)
        {
            Anim.Play("idle");
            isIdle = true;
        }

        Vector2 jump = new Vector2(0, jumpForce * 100);

        transform.Translate(movementInput * Time.deltaTime * moveSpeed, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded() || jumpsLeft > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(jump);
            jumpsLeft--;

            if (!isGrounded())
            {
                isIdle = true;
            }
        }

        if (isGrounded())
        {
            jumpsLeft = maxJumps;
        }

        if (movementInput > 0 && !isFacingRight || movementInput < 0 && isFacingRight)
        {
            Flip();
        }
    }

    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
