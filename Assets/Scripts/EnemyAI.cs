using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    //public GameObject parent;
    public Transform firepoint;
    public GameObject bulletPrefab;
    public GameObject deathEffect;

    float hp = 80;
    float bulletForce = 100f;
    float minDamage = 10f;
    float maxDamage = 50f;
    float rndDamage;

    string lasthit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        takeDamage(collision);
    }

    void Start()
    {
        InvokeRepeating("shoot", .5f, .7f);
        hp += (ScoreMgr.Ascore + ScoreMgr.Bscore)/25;
        minDamage += ((float)ScoreMgr.Ascore + (float)ScoreMgr.Bscore) / 200;
        maxDamage += (ScoreMgr.Ascore + ScoreMgr.Bscore) / 100;
        rndDamage = maxDamage - minDamage;
        //Debug.Log(minDamage.ToString() + " " + maxDamage.ToString() + " " + rndDamage + " " + hp);
    }

    void FixedUpdate()
    {
        if (hp <= 0)
            kill();
    }

    void takeDamage(Collision2D collision)
    {
        float dmg;
        string name = collision.gameObject.name;
        if (name.Contains("Enemy"))
            return;
        lasthit = name;
        if (name.Contains("Damage: "))
        {
            dmg = float.Parse(name.Substring(name.IndexOf("Damage: ") + 8));
        }
        else if (name.Contains("Damagable Box"))
        {
            dmg = 1;
        }
        else
        {
            dmg = 2;
        }
        hp -= dmg;
    }

    void shoot()
    {
        var bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        bullet.name = gameObject.name + " Bullet. Damage: " + (minDamage + Random.value * rndDamage).ToString();
        var body = bullet.GetComponent<Rigidbody2D>();
        body.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void kill()
    {
        var anim = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(anim, .2f);
        ScoreMgr.AddScore(lasthit, 100);
        Destroy(gameObject);
    }
}
