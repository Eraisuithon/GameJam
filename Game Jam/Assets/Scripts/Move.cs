using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    InputManager input;
    Rigidbody2D rb;

    private void Awake()
    {
        input = InputManager.Instance;
        rb = GetComponent<Rigidbody2D>();
    }



}