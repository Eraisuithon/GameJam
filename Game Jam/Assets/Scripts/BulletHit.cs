using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{

    [Header("Effects")]
    public GameObject Effect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        Debug.Log(collisionGameObject.layer);


        if (collisionGameObject.name != "Player")
        {
            BulletDie();
        }
        if (collisionGameObject.name == "Enemy(Clone)")
        {
            Instantiate(Effect, transform.position, Quaternion.identity);
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
