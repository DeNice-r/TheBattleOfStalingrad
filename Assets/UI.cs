using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TankScript Tank1;
    public TankScript Tank2;
    public Shoot shoot1;
    public Shoot shoot2;
    bool paused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            pause();
    }

    void pause()
    {
        Time.timeScale = (paused) ? 1f : 0f;
        paused = !paused;
    }

    public void T1NOBUpgrade() // Tank 1 Number Of Bullets Upgrade
    {
        shoot1.gunUpgrade();
    }

    public void T2NOBUpgrade() // Tank 2 Number Of Bullets Upgrade
    {

    }

    public void T1DmgUpgrade()
    {
        shoot1.dmgUpgrade();
    }
}
