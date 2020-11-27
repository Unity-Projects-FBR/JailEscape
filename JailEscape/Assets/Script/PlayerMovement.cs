using Assets.Script;
using UnityEngine;

public class PlayerMovement : CharacterController2D
{
    public float runSpeed = 40f;
    public Animator animator;
    public float slidingDuration = 0.01f;

    private float horizontalMove = 0f;
    private bool jump = false;
    private bool sliding = false;
    private float timeSlidingCountdown = 0f;

    public void Update()
    {
        if (!sliding)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }
        else
        {
            horizontalMove = FacingRight ? runSpeed : -runSpeed;
        }

        if (Input.GetButtonDown("Jump") && !sliding)
        {
            jump = true;
        }

        if (Input.GetButtonDown("Slide") && !sliding)
        {
            sliding = true;
            animator.SetBool(CharacterAnimatorVariableNames.IsSliding, true);
            timeSlidingCountdown = slidingDuration;
        }
        else if (sliding && timeSlidingCountdown < 0)
        {
            sliding = false;
            animator.SetBool(CharacterAnimatorVariableNames.IsSliding, false);
        }
        animator.SetFloat(CharacterAnimatorVariableNames.Speed, Mathf.Abs(horizontalMove));
        animator.SetBool(CharacterAnimatorVariableNames.IsJumping, !Grounded);
        if (sliding)
        {
            timeSlidingCountdown -= Time.deltaTime;
        }
    }

    public void FixedUpdate()
    {
        base.FixedUpdate();
        Move(horizontalMove * Time.fixedDeltaTime, sliding, jump);
        jump = false;
    }

}