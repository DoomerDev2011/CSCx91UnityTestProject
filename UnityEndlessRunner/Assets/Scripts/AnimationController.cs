using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public Animator animator;

    void Update()
    {
        bool spacePressed = Input.GetKeyDown("space");
        bool isJumping = animator.GetBool("isJumping");

        bool sPressed = Input.GetKeyDown("s");
        bool isRolling = animator.GetBool("isRolling");

        if(!isJumping && spacePressed){
            animator.SetBool("isJumping", true);
        }
        if(isJumping && !spacePressed){
            animator.SetBool("isJumping", false);
        }

        if(!isRolling && sPressed){
            animator.SetBool("isRolling", true);
        }
        if(isRolling && !sPressed){
            animator.SetBool("isRolling", false);
        }
    }
}
