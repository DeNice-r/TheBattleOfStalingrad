using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    public GameObject deathEffect;

    float hp = 70;
    float bulletForce = 100f;
    float minDamage = 10f;
    float maxDamage = 50f;
    float rndDamage;

    public Transform target;

    float speed = 100000f;
    float nextWaypDistance = 2f;

    Path path;
    int currentWayp = 0;
    bool reachedEndOfPath = false;

    bool rotateLeft;
    bool rotateRight;

    Seeker seeker;
    Rigidbody2D rbody;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        takeDamage(collision);
    }

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rbody = GetComponent<Rigidbody2D>();

        

        InvokeRepeating("shoot", .5f, .7f);
        InvokeRepeating("UpdPath", .0f, .7f);
        rndDamage = maxDamage - minDamage;
    }

    void FixedUpdate()
    {
        if (hp <= 0)
            kill();
        if (path == null)
            return;
        //if(currentWayp >= path.vectorPath.Count)
        //{
        //    reachedEndOfPath = true;
        //    return;
        //}
        //else
        //{
        //    reachedEndOfPath = true;
        //}

        //Vector2 dir = ((Vector2)path.vectorPath[currentWayp]-rbody.position).normalized;
        //Vector2 force = dir * speed * Time.deltaTime;

        //var vec1 = ((Vector2)rbody.transform.up - dir);
        
        //Debug.Log((vec1.x < rbody.position.x).ToString() + " " + (vec1.y < rbody.position.y).ToString());

        ////rotateLeft = () ? true : rotateLeft;
        ////rotateLeft = () ? false : rotateLeft;
        ////if (rotateLeft)
        ////{
        ////    rotateSpeedLeft = (rotateSpeedLeft < rotateSpeedMax) ? rotateSpeedLeft + rotateAcceleration : rotateSpeedMax;
        ////}
        ////else
        ////{
        ////    rotateSpeedLeft = (rotateSpeedLeft > 0) ? rotateSpeedLeft - rotateDeceleration : 0;
        ////}
        ////transform.Rotate(0f, 0f, rotateSpeedLeft * Time.deltaTime);

        ////rotateRight = (Input.GetKeyDown(keyRotateRight)) ? true : rotateRight;
        ////rotateRight = (Input.GetKeyUp(keyRotateRight)) ? false : rotateRight;
        ////if (rotateRight)
        ////{
        ////    rotateSpeedRight = (rotateSpeedRight < rotateSpeedMax) ? rotateSpeedRight + rotateAcceleration : rotateSpeedMax;
        ////}
        ////else
        ////{
        ////    rotateSpeedRight = (rotateSpeedRight > 0) ? rotateSpeedRight - rotateDeceleration : 0;
        ////}
        ////transform.Rotate(0f, 0f, rotateSpeedRight * Time.deltaTime * -1f);

        ////moveForward = (Input.GetKeyDown(keyMoveForward)) ? true : moveForward;
        ////moveForward = (Input.GetKeyUp(keyMoveForward)) ? false : moveForward;
        ////if (moveForward)
        ////{
        ////    moveSpeed = (moveSpeed < moveSpeedMax) ? moveSpeed + moveAcceleration : moveSpeedMax;
        ////}
        ////else
        ////{
        ////    moveSpeed = (moveSpeed > 0) ? moveSpeed - moveDeceleration : 0;
        ////}
        ////transform.Translate(0f, moveSpeed * Time.deltaTime, 0f);

        ////moveReverse = (Input.GetKeyDown(keyMoveReverse)) ? true : moveReverse;
        ////moveReverse = (Input.GetKeyUp(keyMoveReverse)) ? false : moveReverse;
        ////if (moveReverse)
        ////{
        ////    moveSpeedReverse = (moveSpeedReverse < moveSpeedMax) ? moveSpeedReverse + moveAcceleration : moveSpeedMax;
        ////}
        ////else
        ////{
        ////    moveSpeedReverse = (moveSpeedReverse > 0) ? moveSpeedReverse - moveDeceleration : 0;
        ////}
        ////transform.Translate(0f, moveSpeedReverse * Time.deltaTime * -1f, 0f);

        //rbody.AddForce(force);

        //float dist = Vector2.Distance(rbody.position, path.vectorPath[currentWayp]);

        //if(dist < nextWaypDistance)
        //{
        //    currentWayp++;
        //}

    }

    void onPathed(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayp = 0;
        }
    }

    void UpdPath()
    {
        if(seeker.IsDone())
            seeker.StartPath(rbody.position, target.position, onPathed);
    }

    void takeDamage(Collision2D collision)
    {
        float dmg;
        string name = collision.gameObject.name;
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
        Destroy(gameObject);
    }
}
