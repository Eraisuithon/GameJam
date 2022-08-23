using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.name != "Player")
        {
            die();
        }
    }
    void die()
    {
        Destroy(gameObject);
    }
}
