using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable_Box : MonoBehaviour
{
    // Start is called before the first frame update

    public float hp = 150;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        takeDamage(collision);
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
            dmg = 0;
        }
        else
        {
            dmg = 2;
        }
        hp -= dmg;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp < 0)
            Destroy(gameObject);
    }
}
