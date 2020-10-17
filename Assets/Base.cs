using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour
{
    public float hp = 1000f;
    public float maxhp = 1000f;
    public float minhp = 0f;
    public float regen = 1f;
    public HealthBar healthBar;
    private Timer timer;
    public GameObject deathEffect;
    // Start is called before the first frame update

    private void Start()
    {
        TimerCallback tm = new TimerCallback(regeneration);
        timer = new Timer(tm, new object(), 0, 200);
        healthBar.slider.maxValue = hp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var iname = collision.gameObject.name;
        float dmg;
        string name = collision.gameObject.name;
        if (name.Contains("Damagable Box"))
        {
            dmg = 5;
        }
        else if (name.Contains("Bullet"))
        {
            dmg = 10 + Random.value * 40f;
        }
        else
        {
            dmg = 2;
        }
        hp -= dmg;
        healthBar.SetHealth(hp);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(hp);
        if (hp <= minhp)
            kill();
    }

    void regeneration(object o)
    {
        Debug.Log("regenerated! " + regen.ToString());
        if (hp + regen < maxhp)
            hp += regen;
        else
            hp = maxhp;
    }

    void kill()
    {
        var anim = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(anim, 1f);
        timer.Dispose();
        Destroy(gameObject);
    }


}
