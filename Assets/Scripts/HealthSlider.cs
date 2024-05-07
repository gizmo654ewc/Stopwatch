using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.minValue = -(health/10);
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
        Debug.Log(health);
    }
}
