using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour
{
    public float hp = 1000f;
    public float maxhp = 1000f;
    public float minhp = 0f;
    public float regen = 5f;
    public int regenrate = 1000;
    public HealthBar healthBar;
    private Timer timer;
    public GameObject deathEffect;
    // Start is called before the first frame update

    private void Start()
    {
        TimerCallback tm = new TimerCallback(regeneration);
        timer = new Timer(tm, new object(), 0, regenrate);
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

    private void OnApplicationQuit()
    {
        timer.Dispose();
    }

    void regeneration(object o)
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
        timer.Dispose();
        Destroy(gameObject);
    }


}
