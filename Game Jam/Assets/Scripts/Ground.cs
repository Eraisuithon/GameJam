using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private bool onGround;
    private float friction;
    public float GetFriction => friction;
    public bool GetOnGround => onGround;

    public float radius;
    public Vector3 offset;
    public LayerMask groundLayer;
    public Vector2 direction;
    public bool ContinousGroundCheck;

    public void CheckOnGround()
    {
        onGround = Physics2D.CircleCast(transform.position + offset, (radius / 2), direction, groundLayer);
    }

    private void Update()
    {
        if (ContinousGroundCheck) CheckOnGround();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        RetrieveFriction(collision);
        CheckOnGround();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        RetrieveFriction(collision);
        CheckOnGround();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        friction = 0;
        onGround = false;
    }

    private void RetrieveFriction(Collision2D collision)
    {
        PhysicsMaterial2D material = collision.rigidbody.sharedMaterial;
        friction = 0;
        if (material != null) friction = material.friction;
    }

   
}
