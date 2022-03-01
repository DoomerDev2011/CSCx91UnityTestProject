using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public bool hit;
    public bool jump;
    public bool slide;
    public bool grounded;
    private bool alive;
    public float speed;
    public float slideSpeed;
    private float speedHolder;
    public float jumpSpeed;
    public float spacingMult = 0;
    public float rowNum;
    public float delay;
    public float groundRadius;
    public Transform groundCheck;
    public float groundCheckDelay;
    public Vector2 rowRange;
    public LayerMask ground;
    public float startRow;
    public float row;
    private bool pressed;
    private Rigidbody rb;
    public float movementX;
    public Collider body;
    public Collider slideSize;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rowNum%2 != 0)
        {
            rowRange = new Vector2 (-((rowNum/2) - 0.5f), (rowNum / 2) - 0.5f);
        }
        else
        {
            rowRange = new Vector2(-(rowNum/2 - 1), rowNum/2);
        }
        if (startRow > rowRange.y) {
            startRow = rowRange.y;
        }
        if (startRow < rowRange.x)
        {
            startRow = rowRange.x;
        }
        row = startRow;
        rb.MovePosition(new Vector3(row * spacingMult, rb.position.y, 0.0f));
        pressed = false;
        alive = true;
        grounded = true;
        delay = groundCheckDelay;
        speedHolder = speed;
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        if (movementVector.y > 0 && grounded)
        {
            slide = false;
            jump = true;
            grounded = false;
        }
        else if (movementVector.y < 0 && grounded) {
            slide = true;
        }
        else
        {
            slide = false;
        }
        movementX = movementVector.x;
    }
    void Update()
    {
        if (movementX > 0 && !pressed)
        {
            if (row != rowRange.y)
            {
                row += 1;
            }
            pressed = true;
        }
        else if (movementX < 0 && !pressed)
        {
            if (row != rowRange.x)
            {
                row += -1;
            }
            pressed = true;
        }
        if (movementX == 0)
        {
            pressed = false;
        }
        if (!grounded)
        {
            delay -= Time.deltaTime;

            if (delay > 0f)
            {
                return;
            }
            Collider[] colliders = Physics.OverlapSphere(groundCheck.position, groundRadius);
            for (int i = 0; i < colliders.Length; i++)
            {
                bool wasGrounded = grounded;
                if (colliders[i].gameObject != gameObject)
                {
                    grounded = true;
                    if (!wasGrounded)
                    {
                        Land();
                    }
                }
            }

        }
        if (slide)
        {
            Slide();
        }
        else
        {
            body.enabled = true;
        }
        if (alive == false)
        {
            Die();
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(new Vector3(row * spacingMult, rb.position.y, 0.0f));
        if (jump)
        {
            rb.AddForce(new Vector3(0.0f, jumpSpeed * 100, 0.0f));
            jump = false;
            grounded = false;
        }
    }
    private void Die()
    {

    }
    private void Slide()
    {
        body.enabled = false;
        speed = slideSpeed;
    }
    private void Land()
    {
        grounded = true;
        delay = groundCheckDelay;
    }

    
}
