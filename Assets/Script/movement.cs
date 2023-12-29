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
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movementInput = Input.GetAxisRaw("Horizontal");
        Vector2 jump = new Vector2(0, jumpForce * 100);

        transform.Translate(movementInput * Time.deltaTime * moveSpeed, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.AddForce(jump);
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
}