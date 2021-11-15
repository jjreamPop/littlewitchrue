using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{

    private float charSpeed = 4F;
    private float jumpHeight = 7.5F;

    public SpriteRenderer sr;
    private Rigidbody2D rb;
    public Animator animator;

    private bool onGround;
    private bool canJump;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        canJump = onGround;

        animator.SetBool("onGround", onGround);

        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            rb.velocity = Vector2.up * jumpHeight;
        }
        animator.SetFloat("fallSpeed", rb.velocity.y);

        float forward = 0;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            sr.flipX = true;
            forward = -charSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            sr.flipX = false;
            forward = charSpeed;
        }
        else
        {
            forward = 0;
        }

        animator.SetFloat("charSpeed", Mathf.Abs(forward));
        rb.velocity = new Vector2(forward, rb.velocity.y);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            transform.parent = collision.gameObject.transform;
            onGround = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            if (transform.parent == collision.gameObject.transform)
            {
                transform.parent = null;
            }
            onGround = false;
        }
    }
}
