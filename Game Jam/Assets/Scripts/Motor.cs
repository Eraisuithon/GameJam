using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
public class Motor : MonoBehaviour
{

    PlayerManager manager;
    Rigidbody2D rb;
  
    [Header("Movement")]
    [SerializeField] private float maxSpeed;
    [SerializeField] private float Acceleration;
    [SerializeField] private Animator animator;

    private Vector2 direction;

    private void Awake()
    {
        manager = GetComponent<PlayerManager>();
        rb = manager.rb;
    }

    private void Update()
    {
        LimitPlayerSpeed();

        direction.x = manager.inputManager.GetHorizontalInput();

        animator.SetFloat("Speed", Mathf.Abs(direction.x));

        if (direction.x > 0.01)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (direction.x < -0.01)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        animator.SetBool("Is_Jumping", !manager.ground.CheckOnGround());

    }

    private void FixedUpdate()
    {
        Move();

    }

    private void Move()
    {
        var vel = direction.x * Acceleration * Time.fixedDeltaTime;
        rb.velocity = ChangeXVelocity(vel);
    }


    private void LimitPlayerSpeed()
    {
        if(rb.velocity.x > maxSpeed)
        {
            rb.velocity = ChangeXVelocity(maxSpeed);
        }
    }

    private Vector2 ChangeXVelocity(float value)
    {
        return new Vector2
        {
            x = value,
            y = rb.velocity.y
        };
    }

  

}
