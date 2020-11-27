using Assets.Script;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public Transform[] moveSpots;
    public Animator animator;
    [Range(0, .3f)] [SerializeField] private float MovementSmoothing = .05f;

    private float startWaitTime;
    private int randomSpot;
    private bool isWaiting;
    private bool facingRight = true;
    private Rigidbody2D Rigidbody2DComponent;
    private Vector3 Velocity = Vector3.zero;

    public void Awake()
    {
		Rigidbody2DComponent = GetComponent<Rigidbody2D>();
        startWaitTime = waitTime;
        randomSpot = 0;
        isWaiting = false;
    }

    public void Update()
    {
        if (!isWaiting)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(moveSpots[randomSpot].position.x, transform.position.y), speed * Time.deltaTime);

            var xDistance = Mathf.Abs(transform.position.x) - Mathf.Abs(moveSpots[randomSpot].position.x);
            isWaiting = -0.1f < xDistance && xDistance < 0.1f;

            animator.SetFloat(CharacterAnimatorVariableNames.Speed, 1);
            FlipCheck();
        }
        else
        {
            waitTime -= Time.deltaTime;
            if(waitTime <= 0)
            {
                waitTime = startWaitTime;
                randomSpot = randomSpot == 0 ? moveSpots.Length - 1 : randomSpot - 1;
                isWaiting = false;
            }
            animator.SetFloat(CharacterAnimatorVariableNames.Speed, 0);
        }
    }

    private void FlipCheck()
    {
        if (Mathf.Abs(transform.position.x) < Mathf.Abs(moveSpots[randomSpot].position.x) && !facingRight)
        {
            Flip();
        }
        else if (Mathf.Abs(transform.position.x) > Mathf.Abs(moveSpots[randomSpot].position.x) && facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
    }
}
