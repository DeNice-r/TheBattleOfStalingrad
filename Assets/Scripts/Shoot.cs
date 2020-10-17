using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    public KeyCode shootkey;

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(shootkey))
        {
            shoot();
        }
    }

    void shoot()
    {
        var bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        var body = bullet.GetComponent<Rigidbody2D>();
        body.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
