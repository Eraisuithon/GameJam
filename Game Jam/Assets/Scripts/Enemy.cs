using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    private float moveSpeed = 2f;
    Vector3 direction;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
        direction = player.position - transform.position + new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (seePlayer())
        {
            direction = player.position - transform.position;
            moveSpeed = 5f;
        }
        else
        {
            moveSpeed = 2f;
        }
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
        if (distSquared < 2) hit(); // 2 is chosen arbitery
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void hit()
    {
        Destroy(gameObject);
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed /= 2;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        moveSpeed *= 2;
    }
    private bool seePlayer()
    {
        RaycastHit2D hit = Physics2D.Linecast(transform.position, player.position);
        if (hit.collider != null && hit.collider.name == "Player")
            return true;
        Debug.Log(hit.collider.name);
        return false;
    }
}
