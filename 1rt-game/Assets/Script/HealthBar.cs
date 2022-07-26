using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public Gradient gradient;
    public Image fill;

    public void initHealth(uint amount)
    {
        healthBar.maxValue = amount;
        healthBar.value = amount;

        fill.color = gradient.Evaluate(1f); // the value A [0, 1] <=> [0%, 100%] of a color asigned in the gradient component
    }

    public void setHealth(uint amount)
    {
        healthBar.value = amount;

        fill.color = gradient.Evaluate(healthBar.normalizedValue);
    }
}
