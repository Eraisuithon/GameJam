using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [Header("Privates")]
    [SerializeField] private float friction;
    [SerializeField] private Animator animator;
    public float GetFriction => friction;
    public bool onGround = false;

    [Header("Variables")]
    public LayerMask groundLayer;
    public Vector3 offset;
    public Vector2 direction;



    public void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            onGround = true;
        }
    }

    public void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            onGround = false;
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, transform.position + offset);
    }

}
