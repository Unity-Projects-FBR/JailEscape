using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float JumpForce = 400f;
    [Range(1, 2)] [SerializeField] private float SlideSpeed = 1.36f;
	[Range(0, .3f)] [SerializeField] private float MovementSmoothing = .05f;
	[SerializeField] private bool AirControl = false;
	[SerializeField] private LayerMask WhatIsGround;
	[SerializeField] private Transform GroundCheck;
	[SerializeField] private Transform CeilingCheck;
	[SerializeField] private Collider2D DefaultCollider;
	[SerializeField] private Collider2D SlideCollider;
	[SerializeField] private Collider2D JumpCollider;

    protected bool FacingRight = true;
    protected bool Grounded;

    private const float GroundedRadius = 1f;
    private const float CeilingRadius = 1f;
	private Rigidbody2D Rigidbody2DComponent;
	private Vector3 Velocity = Vector3.zero;

	public void Awake()
	{
		Rigidbody2DComponent = GetComponent<Rigidbody2D>();
	}

    public void FixedUpdate()
	{
		Grounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundedRadius, WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				Grounded = true;
			}
		}
	}

	public void Move(float xMovement, bool slide, bool jump)
	{
        if (!slide && Physics2D.OverlapCircle(CeilingCheck.position, CeilingRadius, WhatIsGround))
        {
            slide = true;
        }

        if (Grounded || AirControl)
        {
            XMovementControl(xMovement, slide, jump);
        }

        if (Grounded && jump)
		{
			Grounded = false;
            Rigidbody2DComponent.AddForce(new Vector2(0f, JumpForce));
		}
	}

    private void XMovementControl(float xMovement, bool slide, bool jump)
    {
        if (slide)
        {
            xMovement *= SlideSpeed;
        }

        SetActiveCollider(slide, jump);
        CheckPlayerFlip(xMovement);

        Vector3 targetVelocity = new Vector2(xMovement * 10f, Rigidbody2DComponent.velocity.y);
        Rigidbody2DComponent.velocity = Vector3.SmoothDamp(Rigidbody2DComponent.velocity, targetVelocity, ref Velocity, MovementSmoothing);
    }

    private void CheckPlayerFlip(float xMovement)
    {
        if (xMovement > 0 && !FacingRight)
        {
            Flip();
        }
        else if (xMovement < 0 && FacingRight)
        {
            Flip();
        }
    }

    private void SetActiveCollider(bool slide, bool jump)
    {
        if(SlideCollider != null)
            SlideCollider.enabled = slide;
        if (JumpCollider != null)
            JumpCollider.enabled = jump || !Grounded;
        if (DefaultCollider != null)
            DefaultCollider.enabled = !slide && !jump && Grounded;
    }

    private void Flip()
	{
		FacingRight = !FacingRight;
        transform.Rotate(0f, 180f, 0f);
	}
}
