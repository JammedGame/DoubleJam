using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private int jumpAmount, jumpMax;

    public float speed, jumpForce, glideFallSpeed;

    public GameObject graphics;
    private Animator animator;
    private bool isMoving, isGrounded, jump;

    [SerializeField]
    private bool airControl;

    Rigidbody2D rb;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;
    public bool inShadow = false;
    void Start()
    {
        // glideTimeLeft = 1;
        jumpMax = 1;
        rb = GetComponent<Rigidbody2D>();
        animator = graphics.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        isGrounded = IsGrounded();

        HandleMovement(horizontal);
        Flip(horizontal);

        HandleLayers();

        print(rb.velocity.y);

        ResetValues();

        if (Input.GetKey(KeyCode.Space))
        {
            rb.gravityScale = 0.5f;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.gravityScale = 1f;
        }

    }

    void HandleMovement(float horizontal)
    {
        Jump();

        if (rb.velocity.y < -1)
        {
            animator.SetBool("Land", true);
        }

        if (isGrounded || airControl)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (isGrounded && jump)
        {
            isGrounded = false;

            rb.AddForce(new Vector2(0, jumpForce));

            animator.SetTrigger("Jump");
            animator.SetBool("Land", false);
        }
    }

    void Flip(float horizontal)
    {
        if (horizontal > 0)
        {
            graphics.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
        else if (horizontal < 0)
        {
            graphics.transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    private void ResetValues()
    {
        jump = false;
    }

    private bool IsGrounded()
    {
        if (rb.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        animator.ResetTrigger("Jump");
                        animator.SetBool("Land", false);
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void HandleLayers()
    {
        if (!isGrounded)
        {
            animator.SetLayerWeight(1, 1);
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        var sunRay = col.gameObject.GetComponent<SunRay>();

        if (sunRay != null)
        {
            sunRay.Trigger();
        }
    }
}
