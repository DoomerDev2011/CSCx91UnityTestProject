using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public Rigidbody rigidBody;
    public BoxCollider topCollider;

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
        bool isMovingLeft = animator.GetBool("isMovingLeft");
        bool isMovingRight = animator.GetBool("isMovingRight");

        bool spacePressed = Input.GetKeyDown("space");
        bool isJumping = animator.GetBool("isJumping");

        bool sPressed = Input.GetKeyDown("s");
        bool isRolling = animator.GetBool("isRolling");

        bool gameOver = animator.GetBool("gameOver");

        if(!gameOver){
            if(Input.GetKeyDown("a") && !movingLeft && !movingRight && rows > 0){
                rows--;
                currentPos = transform.position;
                tempTarget = currentPos - targetPosition;          
                movingLeft = true;
                animator.SetBool("isMovingLeft", true);
            }
            if(movingLeft){
                moveLeft();
                if(transform.position == currentPos - targetPosition){
                    movingLeft = false;
                    animator.SetBool("isMovingLeft", false);
                    currentPos = Vector3.zero;
                }
            }
        
            if(Input.GetKeyDown("d") && !movingRight && !movingLeft && rows < 2){
                rows++;
                currentPos = transform.position;
                tempTarget = currentPos + targetPosition;
                movingRight = true;
                animator.SetBool("isMovingRight", true);
            }
            if(movingRight){
                moveRight();
                if(transform.position == currentPos + targetPosition){
                    movingRight = false;
                    animator.SetBool("isMovingRight", false);
                    currentPos = Vector3.zero;
                }
            }

        
            if(!isJumping && !isRolling && spacePressed && rigidBody.velocity.y == 0){
                rigidBody.AddForce(jumpHeight * 2.5f, ForceMode.Impulse);
                animator.SetBool("isJumping", true);                                        // jump
            }                                       
            if(isJumping && !spacePressed){
                animator.SetBool("isJumping", false);
            }

            if(!isRolling && rigidBody.velocity.y == 0 && sPressed ){
                animator.SetBool("isRolling", true);                // roll
                topCollider.enabled = false;
            }
            if(isRolling && !sPressed){
                animator.SetBool("isRolling", false);
                Invoke("colliderReset", 1.3f);
            }
        }
        
        if(Input.GetKeyDown("k") && !movingRight && !movingLeft){
            animator.SetBool("gameOver", true);                       // simulated game over
        }

    }

    void moveLeft(){
        transform.position = Vector3.MoveTowards(transform.position, tempTarget, 4f * Time.deltaTime); 
    }

    void moveRight(){
        transform.position = Vector3.MoveTowards(transform.position, tempTarget, 4f * Time.deltaTime);
    }

    void colliderReset(){
        topCollider.enabled = true;
    }

}
