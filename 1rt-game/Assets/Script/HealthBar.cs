using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healtBar;

    public void initHealth(uint amount)
    {
        healtBar.maxValue = amount;
        healtBar.value = amount;
    }

    public void setHealth(uint amount)
    {
        healtBar.value = amount;
    }
}
