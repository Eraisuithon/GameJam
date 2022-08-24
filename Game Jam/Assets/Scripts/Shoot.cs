using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float shootSpeed, shootTimer;

    private bool isShooting;

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isShooting)
        {
            StartCoroutine(shoot());
        }
    }
    IEnumerator shoot()
    {
        isShooting = true;
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
        float radToDegrees = transform.rotation.eulerAngles.z * Mathf.PI / 180;
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * Time.fixedDeltaTime * Mathf.Cos(radToDegrees), shootSpeed * Time.fixedDeltaTime * Mathf.Sin(radToDegrees));
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }
}
