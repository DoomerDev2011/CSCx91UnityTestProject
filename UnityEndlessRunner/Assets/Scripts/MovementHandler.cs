using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public Rigidbody rigidBody;
    public BoxCollider topCollider;

    public AudioSource footstepsSFX;
    public AudioSource jumpSFX;
    public AudioSource strafeSFX;
    public AudioSource rollSFX;
    public AudioSource whackSFX;
    public AudioSource backgroundMusic;
    

    private int rows;
    private Vector3 jumpHeight = new Vector3(0f, 2f, 0f);
    private Vector3 targetPosition = new Vector3(1.5f, 0f, 0f);
    private Vector3 tempTarget;
    private Vector3 currentPos;
    private bool movingRight = false;
    private bool movingLeft = false;
    

    void Start()
    {
        rows = 1;
    }


    void Update()
    {
        targetPosition = new Vector3(targetPosition.x, currentPos.y, 0f);
        bool isMovingLeft = animator.GetBool("isMovingLeft");
        bool isMovingRight = animator.GetBool("isMovingRight");

        bool spacePressed = Input.GetKeyDown("space");
        bool isJumping = animator.GetBool("isJumping");

        bool sPressed = Input.GetKeyDown("s");
        bool isRolling = animator.GetBool("isRolling");

        bool gameOver = animator.GetBool("gameOver");

        if (!gameOver)
        {
            if (Input.GetKeyDown("a") && !movingLeft && !movingRight && rows > 0)
            {
                Debug.Log("a has been pressed");
                rows--;
                currentPos = transform.position;
                tempTarget = currentPos - targetPosition;
                movingLeft = true;
                animator.SetBool("isMovingLeft", true);
                footstepsSFX.Pause();
                strafeSFX.Play();
            }
            if (movingLeft)
            {
                moveLeft();
                if (transform.position == currentPos - targetPosition)
                {
                    movingLeft = false;
                    animator.SetBool("isMovingLeft", false);
                    footstepsSFX.Play();
                    currentPos = Vector3.zero;
                }
            }

            if (Input.GetKeyDown("d") && !movingRight && !movingLeft && rows < 2)
            {
                Debug.Log("b has been pressed");
                rows++;
                currentPos = transform.position;
                tempTarget = currentPos + targetPosition;
                movingRight = true;
                animator.SetBool("isMovingRight", true);
                footstepsSFX.Pause();
                strafeSFX.Play();
            }
            if (movingRight)
            {
                moveRight();
                if (transform.position == currentPos + targetPosition)
                {
                    movingRight = false;
                    animator.SetBool("isMovingRight", false);
                    footstepsSFX.Play();
                    currentPos = Vector3.zero;
                }
            }


            if (!isJumping && !isRolling && spacePressed && rigidBody.velocity.y == 0)
            {
                rigidBody.AddForce(jumpHeight * 2.5f, ForceMode.Impulse);

                animator.SetBool("isJumping", true);
                footstepsSFX.Pause();
                jumpSFX.Play();                                        // jump
            }                                       

            if (isJumping && !spacePressed && rigidBody.velocity.y == 0)
            {
                animator.SetBool("isJumping", false);
                footstepsSFX.Play();
            }

            if (!isRolling && rigidBody.velocity.y == 0 && sPressed)
            {
                animator.SetBool("isRolling", true);                // roll
                topCollider.enabled = false;
                footstepsSFX.Pause();
                rollSFX.Play();
            }
            if (isRolling && !sPressed)
            {
                animator.SetBool("isRolling", false);
                Invoke("colliderReset", 1.3f);
            }
        }

        
        if(Input.GetKeyDown("k") && !movingRight && !movingLeft){
            backgroundMusic.Stop();
            footstepsSFX.Stop();
            whackSFX.Play();

            animator.SetBool("gameOver", true);                       // simulated game over
        }

    }

    void moveLeft()
    {
        transform.position = Vector3.MoveTowards(transform.position, tempTarget, 4f * Time.deltaTime);
    }

    void moveRight()
    {
        transform.position = Vector3.MoveTowards(transform.position, tempTarget, 4f * Time.deltaTime);
    }


    void colliderReset(){
        footstepsSFX.Play();

        topCollider.enabled = true;

    }
}
