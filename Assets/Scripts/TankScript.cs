using System;
using UnityEngine;

public class TankScript : MonoBehaviour
{
    public TrackScript trackLeft;
    public TrackScript trackRight;

    public KeyCode keyMoveForward;
    public KeyCode keyMoveReverse;
    public KeyCode keyRotateRight;
    public KeyCode keyRotateLeft;

    public HealthBar healthBar;
    public GameObject deathEffect;

    bool moveForward = false;
    bool moveReverse = false;
    float moveSpeed = 0f;
    float moveSpeedReverse = 0f;
    float moveAcceleration = 1.2f;
    float moveDeceleration = 2.8f;
    float moveSpeedMax = 25f;

    bool rotateRight = false;
    bool rotateLeft = false;
    float rotateSpeedRight = 0f;
    float rotateSpeedLeft = 0f;
    float rotateAcceleration = 25f;
    float rotateDeceleration = 50f;
    float rotateSpeedMax = 100f;

    float hp = 100f;
    float armor = 100f;
    //float maxarmor = 100f;
    float minarmor = 0f;
    //float maxhp = 100f;
    float minhp = 0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        takeDamage(collision);
        
    }

    void Update()
    {
        if (hp <= minhp)
            kill();

        rotateLeft = (Input.GetKeyDown(keyRotateLeft)) ? true : rotateLeft;
        rotateLeft = (Input.GetKeyUp(keyRotateLeft)) ? false : rotateLeft;
        if (rotateLeft)
        {
            rotateSpeedLeft = (rotateSpeedLeft < rotateSpeedMax) ? rotateSpeedLeft + rotateAcceleration : rotateSpeedMax; } else { rotateSpeedLeft = (rotateSpeedLeft > 0) ? rotateSpeedLeft - rotateDeceleration : 0;
        }
        transform.Rotate(0f, 0f, rotateSpeedLeft * Time.deltaTime);

        rotateRight = (Input.GetKeyDown(keyRotateRight)) ? true : rotateRight;
        rotateRight = (Input.GetKeyUp(keyRotateRight)) ? false : rotateRight;
        if (rotateRight)
        {
            rotateSpeedRight = (rotateSpeedRight < rotateSpeedMax) ? rotateSpeedRight + rotateAcceleration : rotateSpeedMax; } else { rotateSpeedRight = (rotateSpeedRight > 0) ? rotateSpeedRight - rotateDeceleration : 0;
        }
        transform.Rotate(0f, 0f, rotateSpeedRight * Time.deltaTime * -1f);

        moveForward = (Input.GetKeyDown(keyMoveForward)) ? true : moveForward;
        moveForward = (Input.GetKeyUp(keyMoveForward)) ? false : moveForward;
        if (moveForward)
        {
            moveSpeed = (moveSpeed < moveSpeedMax) ? moveSpeed + moveAcceleration : moveSpeedMax; } else { moveSpeed = (moveSpeed > 0) ? moveSpeed - moveDeceleration : 0;
        }
        transform.Translate(0f, moveSpeed * Time.deltaTime, 0f);

        moveReverse = (Input.GetKeyDown(keyMoveReverse)) ? true : moveReverse;
        moveReverse = (Input.GetKeyUp(keyMoveReverse)) ? false : moveReverse;
        if (moveReverse)
        {
            moveSpeedReverse = (moveSpeedReverse < moveSpeedMax) ? moveSpeedReverse + moveAcceleration : moveSpeedMax; } else { moveSpeedReverse = (moveSpeedReverse > 0) ? moveSpeedReverse - moveDeceleration : 0;
        }
        transform.Translate(0f, moveSpeedReverse * Time.deltaTime * -1f, 0f);

        if (moveForward | moveReverse | rotateRight | rotateLeft)
        {
            trackStart();
        }
        else
        {
            trackStop();
        }

    }

    void trackStart()
    {
        trackLeft.animator.SetBool("isMoving", true);
        trackRight.animator.SetBool("isMoving", true);
    }

    void trackStop()
    {
        trackLeft.animator.SetBool("isMoving", false);
        trackRight.animator.SetBool("isMoving", false);
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
            dmg = 5;
        }
        else
        {
            dmg = 2;
        }
        float deltadmg = dmg - armor;
        if (deltadmg <= 0)
            armor -= dmg;
        else
        {
            armor = minarmor;
            hp -= deltadmg;
        }
        healthBar.SetHealth(armor, hp);
    }

    void kill()
    {
        var anim = Instantiate(deathEffect, transform.position, Quaternion.identity);

        Destroy(anim, .2f);
        Destroy(gameObject);
    }

}
