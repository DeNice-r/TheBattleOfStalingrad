using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour
{
    float hp = 1000f;
    float maxhp = 1000f;
    float minhp = 0f;
    float regen = 5f;
    float regenrate = 1f;
    public HealthBar healthBar;
    public GameObject deathEffect;
    // Start is called before the first frame update

    void Start()
    {
        InvokeRepeating("regeneration", 1f, regenrate);
        healthBar.slider.maxValue = hp;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        takeDamage(collision);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(hp);
        if (hp <= minhp)
            kill();
    }

    void regeneration()
    {
        if (hp + regen < maxhp)
            hp += regen;
        else
            hp = maxhp;
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

        hp -= dmg;
        healthBar.SetHealth(hp);
    }

    void kill()
    {
        var anim = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(anim, 1f);
        Destroy(gameObject);
    }


}
