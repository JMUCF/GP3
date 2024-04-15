using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       CheckMovement();
       CheckJump();
       CheckShoot();

    }

    private void CheckMovement()
    {
         //check forward movement
        if(Input.GetKey("w") && !Input.GetKey("s") && !Input.GetKey("a") && !Input.GetKey("d"))
        {
            animator.SetBool("isRunning", true);
        }
  
        //check backward movement
        if(Input.GetKey("s") && !Input.GetKey("w") && !Input.GetKey("a") && !Input.GetKey("d"))
        {
            animator.SetBool("isRunning", true);
        }

        //get left movement
         if(Input.GetKey("a") && !Input.GetKey("w") && !Input.GetKey("s") && !Input.GetKey("d"))
        {
            animator.SetBool("isRunning", true);
        }

        //get right movement
           if(Input.GetKey("d") && !Input.GetKey("w") && !Input.GetKey("s") && !Input.GetKey("a"))
        {
            animator.SetBool("isRunning", true);
        }

          //stop movement
        if(!Input.GetKey("s") && !Input.GetKey("w") && !Input.GetKey("a") && !Input.GetKey("d"))
        {
            animator.SetBool("isRunning", false);
        }

    }

    private void CheckJump()
    {
        //check jumping
        if(Input.GetKey("space"))
        {
            animator.SetBool("isJumping", true);
            animator.speed = 3;
        }
        
        else
        {
            animator.SetBool("isJumping", false);
            animator.speed = 1;
        }

        
    }

    private void CheckShoot()
    {
        if(Input.GetMouseButton(0))
        {
            animator.SetBool("isShooting", true);
            animator.speed = 3;
        }

        else
        {
            animator.SetBool("isShooting", false);
            animator.speed = 1;
        }
    }
    
}
