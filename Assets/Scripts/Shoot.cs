using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform[] firepoints;
    public GameObject[] guns;
    public GameObject bulletPrefab;
    public KeyCode shootkey;
    [HideInInspector]
    public int numofbullets = 1;

    [HideInInspector]
    public float bulletForce = 100f;

    void Update()
    {
        if (Input.GetKeyDown(shootkey))
        {
            shoot();
        }
    }

    public void gunUpgrade()
    {
        numofbullets++;
        switch (numofbullets)
        {
            case 2:
                guns[0].SetActive(false);
                guns[1].SetActive(true);
                break;
            case 3:
                guns[1].SetActive(false);
                guns[2].SetActive(true);
                break;
        }
    }

    public void dmgUpgrade()
    {
        
    }

    void shoot()
    {
        //switch (numofbullets) {
        //    case 1:
        //        {
                    shot(0);
        //        }
        //        break;
        //    case 2:
        //        {
        //            shot(1);
        //            shot(2);
        //        }
        //        break;
        //    case 3:
        //        {
        //            shot(0);
        //            shot(1);
        //            shot(2);
        //        }
        //        break;
        //}
    }

    void shot(int n)
    {
        var bullet = Instantiate(bulletPrefab, firepoints[n].position, firepoints[n].rotation);
        bullet.name = gameObject.name + " Bullet. Damage: " + (10 + Random.value * 40f).ToString();
        var body = bullet.GetComponent<Rigidbody2D>();
        body.AddForce(firepoints[n].up * bulletForce, ForceMode2D.Impulse);
    }
}
