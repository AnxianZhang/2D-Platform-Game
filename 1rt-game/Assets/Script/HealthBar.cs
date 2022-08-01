using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Gradient gradient;
    public Image fill;

    public Slider healthBar;

    // doesn't work when healthBar attribut is in private, whyyyy ???
    //private void Awake()
    //{
    //    this.healthBar = gameObject.GetComponent<Slider>();
    //}

    public void initHealth(uint amount)
    {
        this.healthBar.maxValue = amount;
        this.healthBar.value = amount;

        this.fill.color = gradient.Evaluate(1f); // the value A [0, 1] <=> [0%, 100%] of a color asigned in the gradient component
    }

    public void setHealth(uint amount)
    {
        this.healthBar.value = amount;
        this.fill.color = gradient.Evaluate(this.healthBar.normalizedValue);
    }
}
