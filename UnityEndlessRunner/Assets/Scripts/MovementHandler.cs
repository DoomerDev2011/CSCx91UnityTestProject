using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    public GameObject player;
    public Animator animator;

    private int rows;
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
        bool aPressed = Input.GetKeyDown("a");
        bool isMovingLeft = animator.GetBool("isMovingLeft");

        bool dPressed = Input.GetKeyDown("d");
        bool isMovingRight = animator.GetBool("isMovingRight");

        bool spacePressed = Input.GetKeyDown("space");
        bool isJumping = animator.GetBool("isJumping");

        bool sPressed = Input.GetKeyDown("s");
        bool isRolling = animator.GetBool("isRolling");

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
        


        if(!isJumping && spacePressed){
            animator.SetBool("isJumping", true);                // jump
        }                                       
        if(isJumping && !spacePressed){
            animator.SetBool("isJumping", false);
        }

        if(!isRolling && sPressed){
            animator.SetBool("isRolling", true);                // roll
        }
        if(isRolling && !sPressed){
            animator.SetBool("isRolling", false);
        }

    }

    void moveLeft(){
        transform.position = Vector3.MoveTowards(transform.position, tempTarget, 4f * Time.deltaTime); 
         
    }

    void moveRight(){
        transform.position = Vector3.MoveTowards(transform.position, tempTarget, 4f * Time.deltaTime);
    
    }

}
