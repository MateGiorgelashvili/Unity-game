using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public ParticleSystem dust;

    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float jumpForce = 300f;

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

    public bool doubleJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }


    void Update()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (isTouchingWallL() && horizontalInput < 0)
        {
            horizontalInput = 0f;
        }

        if (isTouchingWallR() && horizontalInput > 0)
        {
            horizontalInput = 0f;
        }

        if (horizontalInput != 0)
        {
            Anim.SetBool("Run", true);
        }
        else
        {
            Anim.SetBool("Run", false);
        }


        Vector2 jump = new Vector2(0, jumpForce * 100);

        transform.Translate(horizontalInput * Time.deltaTime * moveSpeed, 0, 0);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);


                if (doubleJump || !isGrounded())
                {
                    CreateDust();
                }
                doubleJump = !doubleJump;
            }
        }
        if (horizontalInput > 0 && !isFacingRight || horizontalInput < 0 && isFacingRight)
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
            doubleJump = false;
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

    void CreateDust()
    {
        dust.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            doubleJump = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        doubleJump = true;
    }
}