using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    InputManager input;
    Rigidbody2D rb;
    GroundCheck groundCheck;

    [SerializeField, Range(0, 100)] private float maxSpeed;
    [SerializeField , Range(0,100)] private float maxAccelration = 35f;
    [SerializeField, Range(0, 100)] private float maxAirAccelration = 20f;

    
    private void Awake()
    {
        input = InputManager.Instance;
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<GroundCheck>();
    }

    private void Update()
    {
        print(groundCheck.IsGrounded(Vector2.down));
    }



}