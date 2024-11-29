using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed= 5f;
    public float jumpForce = 5f;
    public bool isGrounded = false;
    public bool isJumping = false;
    private Rigidbody2D rb;

    // Update is called once per frame
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float movementX = Input.GetAxis("Horizontal");
        //float movementY = Input.GetAxis("Vertical");
        rb.velocity= new Vector2 (movementX * moveSpeed,rb.velocity.y);
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity=new Vector2 (rb.velocity.x,jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            isJumping = true;
        }
    }

}
