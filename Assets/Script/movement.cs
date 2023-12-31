using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float jumpForce = 3f;

    public Vector2 boxSize = new Vector2(1, 0.2f);
    public float castDistance = 0.65f;
    public LayerMask groundLayer;

    public Vector2 boxSize1 = new Vector2(1, 0.2f);
    public float castDistance1 = 0.65f;
    public LayerMask groundLayer1;

    public Vector2 boxSize2 = new Vector2(1, 0.2f);
    public float castDistance2 = 0.65f;
    public LayerMask groundLayer2;

    private bool isFacingRight = true;
    Animator Anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        float movementInput = Input.GetAxisRaw("Horizontal");

        if(isTouchingWallL() && movementInput < 0)
        {
            movementInput = 0f;
        }

        if (isTouchingWallR() && movementInput > 0)
        {
            movementInput = 0f;
        }

        if (movementInput != 0)
        {
            Anim.Play("run");
        }


        Vector2 jump = new Vector2(0, jumpForce * 100);

        transform.Translate(movementInput * Time.deltaTime * moveSpeed, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.AddForce(jump);
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

    public bool isTouchingWallL()
    {
        if (Physics2D.BoxCast(transform.position, boxSize1, 0, -transform.right, castDistance1, groundLayer1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool isTouchingWallR()
    {
        if (Physics2D.BoxCast(transform.position, boxSize2, 0, transform.right, castDistance2, groundLayer2))
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
        Gizmos.DrawWireCube(transform.position - -transform.right * castDistance1, boxSize1);
        Gizmos.DrawWireCube(transform.position - transform.right * castDistance2, boxSize2);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}