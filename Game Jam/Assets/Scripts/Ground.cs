using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [Header("Privates")]
    [SerializeField] private bool onGround;
    [SerializeField] private float friction;
    public float GetFriction => friction;
    public bool GetOnGround => onGround;

    [Header("Variables")]
    public bool ContinousGroundCheck;
    public LayerMask groundLayer;
    public Vector3 offset;
    public Vector2 direction;

    public bool CheckOnGround()
    {
        return Physics2D.Linecast(transform.position, transform.position + offset, groundLayer);
    }

    private void Update()
    {
        if (ContinousGroundCheck) onGround = CheckOnGround();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, transform.position + offset);
    }


   
}
