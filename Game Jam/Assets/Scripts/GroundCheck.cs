using UnityEngine;


public class GroundCheck : MonoBehaviour
{
    public Vector3 offset;
    public float radius;
    public LayerMask groundLayer;

    public bool IsGrounded(Vector2 direction)
    {
        Vector3 _offset = transform.position + offset;
        var grounded = Physics2D.CircleCast(_offset, radius, direction, radius, groundLayer);
        return grounded;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        var _offset = transform.position + offset;
        Gizmos.DrawWireSphere(_offset, radius);
    }
}
