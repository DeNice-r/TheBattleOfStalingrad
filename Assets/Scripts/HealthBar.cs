using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Image img;
    

    // Start is called before the first frame update
    

    // Update is called once per frame
    public void SetHealth(float armor, float hp)
    {
        if (armor > 0) {
            slider.value = armor;
            img.color = new Color32(100, 100, 100, 255);
        }
        else
        {
            slider.value = hp;
            img.color = new Color32(255, 0, 0, 255);
        }
        //this.GetComponent<Image>().color = new Color32(230, 230, 230, 100);
    }
}
