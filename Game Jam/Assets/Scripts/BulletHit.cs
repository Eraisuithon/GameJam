using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{

    [Header("Effects")]
    public GameObject Effect;
    public AudioSource hitSound;
    public AudioSource dieSound;

    private GameObject SoundController;
    void Start()
    {
        SoundController = GameObject.Find("Sound Controller");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        Debug.Log(collisionGameObject.layer);


        BulletDie();

        if (collisionGameObject.name == "Enemy(Clone)")
        {
            Instantiate(Effect, transform.position, Quaternion.identity);
            float hp = --collisionGameObject.GetComponent<Enemy>().hp;
            if (hp <= 0)
            {
                SoundController.GetComponent<SoundController>().playEnemyDieSound();
                EnemyDie(collisionGameObject);
            }
            else
            {
                SoundController.GetComponent<SoundController>().playHitSound();
            }
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
