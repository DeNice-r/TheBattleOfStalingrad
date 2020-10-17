using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable_Box : MonoBehaviour
{
    // Start is called before the first frame update

    public int hp = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hp -= 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp < 0)
            Destroy(gameObject);
    }
}
