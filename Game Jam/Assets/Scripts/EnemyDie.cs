using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            die();
        }
    }
    void die()
    {
        Destroy(gameObject);
    }
}
