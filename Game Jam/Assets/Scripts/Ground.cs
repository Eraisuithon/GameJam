using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [Header("Privates")]
    [SerializeField] private bool onGround;
    [SerializeField] private float friction;
    [SerializeField] private Animator animator;
    public float GetFriction => friction;
    public bool GetOnGround => onGround;

    [Header("Variables")]
    public bool ContinousGroundCheck;
    public LayerMask groundLayer;
    public Vector3 offset;
    public Vector2 direction;

    private Collider2D playerCollider;

    void Awake()
    {
        playerCollider = GameObject.Find("Frictionless").GetComponent<Collider2D>();
    }

    public bool CheckOnGround()
    {
        bool isOnGround = GetComponent<Collider2D>().IsTouching(playerCollider);
        return isOnGround;
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
