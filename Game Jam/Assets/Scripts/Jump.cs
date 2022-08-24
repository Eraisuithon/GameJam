using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
public class Jump : MonoBehaviour
{
    PlayerManager manager;
    Rigidbody2D rb;

    [Range(0, 20)]
    public float jumpVelocity;
    public float jumpHoldGravityMulitplier = 2.5f;
    public float freeFallGravityMultiplier = 2f;
    public float extaGravity;

    [Header("Effects")]
    public GameObject Effect;
    public AudioSource jumpSound;

    private void Awake()
    {
        manager = GetComponent<PlayerManager>();
        rb = manager.rb;
    }

    private void JumpTriggered()
    {
        if (manager.ground.CheckOnGround())
        {

            //rb.velocity = new Vector2
            //{
            //    x = rb.velocity.x,
            //    y = jumpVelocity
            //};

            jumpSound.Play();

            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(jumpVelocity * Vector2.up , ForceMode2D.Impulse);

            manager.shake.ShakeScreen();
            Instantiate(Effect, transform.position, Quaternion.identity);

        }
    }

    private void Update()
    {
        rb.AddForce(extaGravity * Vector2.down);
        if (rb.velocity.y < 0)
        {
            rb.velocity += (jumpHoldGravityMulitplier - 1) * Physics2D.gravity.y * Time.deltaTime * Vector2.up;

        } else if(rb.velocity.y > 0 && !InputManager.Instance.GetJumpHold())
        {
            rb.velocity += (freeFallGravityMultiplier - 1) * Physics2D.gravity.y * Time.deltaTime * Vector2.up;
        } 


    }


    private void OnEnable() => InputManager.Instance.OnJumpTriggered += JumpTriggered;
    private void OnDisable() => InputManager.Instance.OnJumpTriggered -= JumpTriggered;

}
