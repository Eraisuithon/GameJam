using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bullet");
        GameObject collisionGameObject = collision.gameObject;

        BulletDie();
        if(collisionGameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            EnemyDie(collisionGameObject);
        }
    }
    void BulletDie()
    {
        Destroy(gameObject);
    }
    void EnemyDie(GameObject enemy)
    {
        Destroy(enemy);
    }
}
