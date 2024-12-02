using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("X Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxMoveSpeed;
    [SerializeField] private float slowSpeed;
    [SerializeField] private float dashPower;
    [SerializeField] private float maxDashPower;

    [Header("Y Movement")]
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float jumpReleaseMod;

    [Header("Extras")]
    [SerializeField] private LayerMask jumpableGround;
    //private bool playerGrounded = false;
    private float xDirection;
    private float currentXSpeed = 0f;
    public bool isDashing = false;
    public bool facingRight = true;

    [Header("References")]
    private Rigidbody2D rb;
    private Collider2D coll;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //which direction is player facing
        xDirection = Input.GetAxisRaw("Horizontal");
        if (xDirection > 0)
        {
            facingRight = true;
        }
        else if (xDirection < 0)
        {
            facingRight = false;
        }

        VerticalMovement();
        DashLogic();
    }

    private void FixedUpdate()
    {
        HorizontalMovement();
    }

    private void HorizontalMovement()
    {
        if (isDashing)
        {
            return;
        }

        //if pressing left/right
        if (xDirection != 0)
        {
            currentXSpeed += xDirection * 5.0f;
            currentXSpeed = Mathf.Clamp(currentXSpeed, -maxMoveSpeed, maxMoveSpeed);
            rb.linearVelocity = new Vector2(rb.linearVelocityX + currentXSpeed * moveSpeed, rb.linearVelocity.y);
        }

        //if not pressing left/right
        else
        {
            //which direction to slow down
            if (rb.linearVelocityX < 0)
            {
                currentXSpeed += slowSpeed;
                currentXSpeed = Mathf.Clamp(currentXSpeed, -maxMoveSpeed, 0f);
            }
            else if (rb.linearVelocityX > 0)
            {
                currentXSpeed -= slowSpeed;
                currentXSpeed = Mathf.Clamp(currentXSpeed, 0f, maxMoveSpeed);
            }
            rb.linearVelocity = new Vector2(currentXSpeed * moveSpeed, rb.linearVelocityY);
        }

        if (Mathf.Abs(rb.linearVelocityX) > maxMoveSpeed)
        {
            rb.linearVelocityX = Mathf.Clamp(rb.linearVelocityX, -maxMoveSpeed, maxMoveSpeed);
        }
    }

    private void VerticalMovement()
    {
        bool jumpIsReleased = Input.GetButtonUp("Jump");

        //jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocityY = jumpSpeed;
        }

        //variable jump height
        if (jumpIsReleased && rb.linearVelocityY > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, rb.linearVelocityY / jumpReleaseMod);
        }
    }

    //called in BobScript
    public void DashMovement(float xDistance, float yDistance)
    {
        isDashing = true;

        //add x force to player
        float currentDashPower = dashPower * xDistance;
        currentDashPower = Mathf.Clamp(currentDashPower, -maxDashPower, maxDashPower);
        rb.AddForce(currentDashPower * transform.right, ForceMode2D.Impulse);

        //add y force to player
        currentDashPower = dashPower * yDistance;
        currentDashPower /= 2.0f;
        currentDashPower = Mathf.Clamp(currentDashPower, -maxDashPower, maxDashPower);
        rb.AddForce(-currentDashPower * transform.up, ForceMode2D.Impulse);
    }

    private void DashLogic()
    {
        //if player has no x velocity
        if (Mathf.Abs(rb.linearVelocityX) < .01f)
        {
            rb.linearVelocityX = 0f;
            isDashing = false;
        }
        //if player moves against dash direction
        if (isDashing && ((xDirection == -1 && rb.linearVelocityX > 0) || (xDirection == 1 && rb.linearVelocityX < 0)))
        {
            isDashing = false;
        }
        //if dashing is slower than maxMoveSpeed
        if (isDashing && Mathf.Abs(rb.linearVelocityX) < maxMoveSpeed)
        {
            isDashing = false;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .3f, jumpableGround);
    }
}
