using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class RunnerControl : MonoBehaviour
{
    public bool hit;
    public bool grounded;
    public float groundRadius;
    public Transform groundCheck;
    public float groundCheckDelay;
    public float delay;
    public LayerMask ground;
    public float speed;
    public float jumpSpeed;
    public float spacingMult = 0;
    public float rowNum;
    public Vector2 rowRange;
    public float startRow;
    public float row;
    private bool pressed;
    private Rigidbody rb;
    public Animator animator;
    public float movementX;
    public Collider body;
    public Collider slideSize;
    public AudioSource DieSfx;
    public Collider topCollider;
    public Collider bottomCollider;
    public Vector3 tempTarget;
    public Vector3 targetPosition;
    public bool movingRight = false;
    public bool movingLeft = false;
    public bool spacePressed;
    public bool isJumping;
    public bool isRolling;
    public bool gameOver;

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
        rb.MovePosition(new Vector3(5f, rb.position.y, row * spacingMult));
        pressed = false;
        targetPosition = new Vector3(spacingMult, 0f, 0f);
        grounded = true;
        delay = groundCheckDelay;

    }

    void Update()
    {
        
        bool isMovingLeft = animator.GetBool("isMovingLeft");
        bool isMovingRight = animator.GetBool("isMovingRight");

        spacePressed = Input.GetKey("space");
        isJumping = animator.GetBool("isJumping");

        bool sPressed = Input.GetKey("s");
        isRolling = animator.GetBool("isRolling");

        gameOver = animator.GetBool("gameOver");
        Vector3 currentPos = transform.position;


        if (!gameOver)
        {

            if (Input.GetKeyDown("a") && !movingLeft && !movingRight && !pressed)
            {

                if (row != rowRange.y)
                {
                    row++;
                    tempTarget = currentPos - targetPosition;
                    movingLeft = true;
                    pressed = true;
                    animator.SetBool("isMovingLeft", true);
                }
                
            }

            if (Input.GetKeyDown("d") && !movingRight && !movingLeft &&!pressed)
            {
                if (row != rowRange.x)
                {
                    row--;
                    currentPos = transform.position;
                    tempTarget = currentPos + targetPosition;
                    movingRight = true;
                    animator.SetBool("isMovingRight", true);
                }
            }
            if (movingLeft)
            {
                moveLeft();
                if (transform.position.x == tempTarget.x)
                {
                    movingLeft = false;
                    animator.SetBool("isMovingLeft", false);
                    currentPos = Vector3.zero;
                }
            }
            if (movingRight)
            {
                moveRight();
                if (transform.position.x == tempTarget.x)
                {
                    movingRight = false;
                    animator.SetBool("isMovingRight", false);
                    currentPos = Vector3.zero;
                }
            }


            if (!isJumping && spacePressed && rb.velocity.y == 0.0f)
            {
                rb.AddForce(new Vector3(0, jumpSpeed ,0), ForceMode.Impulse);
                animator.SetBool("isJumping", true);                                        // jump
            }
            if (isJumping && !spacePressed)
            {
                animator.SetBool("isJumping", false);
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
            if (!isRolling && rb.velocity.y == 0 && sPressed)
            {
                Roll();
            }
            if (isRolling && !sPressed)
            {
                animator.SetBool("isRolling", false);
                Invoke("colliderReset", 1.3f);
            }
            if (Input.GetKeyDown("k") && !movingRight && !movingLeft)
            {
                animator.SetBool("gameOver", true);                       // simulated game over
            }

        }
        else if (movementX > 0 && !pressed)
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
        if (!isRolling)
        {
            topCollider.enabled = true;
        }
        else
        {
            topCollider.enabled = false;
        }
    }
    private void FixedUpdate()
    {
    }
    void moveLeft()
    {
        if (transform.position.x > tempTarget.x)
        {
            if (rb.velocity.x > -speed)
            {

                rb.AddForce(new Vector3(-speed * 100, 0f, 0f));
            }
        }
        else
        {
            rb.isKinematic = true;
            rb.velocity.Set(0, rb.velocity.y, rb.velocity.z);
            rb.position = new Vector3(tempTarget.x, rb.position.y, rb.position.z);
            rb.isKinematic = false;
        }
    }

    void moveRight()
    {
        if(transform.position.x < tempTarget.x)
        {
            if (rb.velocity.x < speed)
            {

                rb.AddForce(new Vector3(speed*100, 0f, 0f));
            }
            
        }
        else
        {
            rb.isKinematic = true;
            rb.velocity.Set(0, rb.velocity.y, rb.velocity.z);
            rb.position = new Vector3(tempTarget.x, rb.position.y, rb.position.z);
            rb.isKinematic = false;
        }
        
    }
    public void Die()
    {
        animator.SetBool("gameOver", true);
    }
    public void UseItem()
    {
        DieSfx.Play();
    }


    private void Roll()
    {
        animator.SetBool("isRolling", true);                // roll
        topCollider.enabled = false;
    }
    private void Land()
    {
        grounded = true;
        delay = groundCheckDelay;
    }


}
