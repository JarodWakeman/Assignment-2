using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour

    
{
    public Player controller;
    public Animator animator;

    public float horizontalMove = 0f;
    public float runspeed = 40f;
    bool jump = false;
    bool crouch = false;
    bool attack = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


        if (Input.GetButtonDown("Jump")) {
            jump = true;
            animator.SetBool("Jump", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            animator.SetBool("Crouch", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            animator.SetBool("Crouch", false);
        }
        if (Input.GetButtonDown("Attack"))
        {
            attack = true;
            animator.SetBool("Attack", true);
        }
        else if (Input.GetButtonUp("Attack"))
        {
            attack = false;
            animator.SetBool("Attack", false);
        }
    }

    public void onLanding()
    {
        animator.SetBool("Jump", false);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        
    }
}
