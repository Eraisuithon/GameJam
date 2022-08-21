using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    private float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        float distSquared = (transform.position.x - player.transform.position.x) * (transform.position.x - player.transform.position.x) +
                            (transform.position.y - player.transform.position.y) * (transform.position.y - player.transform.position.y);
        if (distSquared < 2) return; // 2 is chosen arbitery
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = 1f;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        moveSpeed = 5f;
    }
}
