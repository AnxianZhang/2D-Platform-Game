using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private uint maxHealth = 100;
    public uint currentHealth;

    public bool isImun = false;
    private float waitingSecong = .125f;
    private float imunTime = .8f;

    public SpriteRenderer sR;
    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.initHealth(currentHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) //test
            takeDamage(20);
    }

    public void takeDamage(uint amount)
    {
        if (!isImun)
            if (currentHealth - amount > 0)
            {
                currentHealth -= amount;
                healthBar.setHealth(currentHealth);
                StartCoroutine(imunityTime());
                StartCoroutine(imunity());
            }
    }

    private IEnumerator imunity()
    {
        isImun = true;
        while (isImun)
        {
            sR.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(waitingSecong);
            sR.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(waitingSecong);
        }
    }

    private IEnumerator imunityTime()
    {
        yield return new WaitForSeconds(imunTime);
        isImun = false;
    }
}
