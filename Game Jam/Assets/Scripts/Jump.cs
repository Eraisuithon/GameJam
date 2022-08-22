using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
public class Jump : MonoBehaviour
{
    PlayerManager manager;
    Rigidbody2D rb;

    [Range(0, 20)]
    public float jumpVelocity;
    public float fallMultiplier = 2.5f;
    public float lowJumpMulitplier = 2f;

    private void Awake()
    {
        manager = GetComponent<PlayerManager>();
        rb = manager.rb;
    }

    private void JumpTriggered()
    {
        rb.velocity = new Vector2
        {
            x = rb.velocity.x,
            y = jumpVelocity
        };
    }

    private void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += (fallMultiplier - 1) * Physics2D.gravity.y * Time.deltaTime * Vector2.up;
        } else if(rb.velocity.y > 0 && !InputManager.Instance.GetJumpHold())
        {
            rb.velocity += (lowJumpMulitplier - 1) * Physics2D.gravity.y * Time.deltaTime * Vector2.up;
        } 


    }


    private void OnEnable() => InputManager.Instance.OnJumpTriggered += JumpTriggered;
    private void OnDisable() => InputManager.Instance.OnJumpTriggered -= JumpTriggered;

}
