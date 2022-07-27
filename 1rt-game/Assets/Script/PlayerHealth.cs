using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private uint maxHealth = 100;
    public uint currentHealth;

    public bool isImun = false;
    private const float WAITIING_TIME = .125f;
    private const float IMUN_TIME = .8f;

    public SpriteRenderer sR;
    public HealthBar healthBar;

    private void Start()
    {
        this.currentHealth = this.maxHealth;
        this.healthBar.initHealth(this.currentHealth);
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
                this.healthBar.setHealth(this.currentHealth);
                StartCoroutine(imunityTime());
                StartCoroutine(imunity());
            }
    }

    private IEnumerator imunity()
    {
        this.isImun = true;
        while (this.isImun)
        {
            this.sR.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(WAITIING_TIME);
            this.sR.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(WAITIING_TIME);
        }
    }

    private IEnumerator imunityTime()
    {
        yield return new WaitForSeconds(IMUN_TIME);
        this.isImun = false;
    }
}
