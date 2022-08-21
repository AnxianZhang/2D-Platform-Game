using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 100;
    private int currentHealth;

    private bool isImun = false;
    private const float WAITIING_TIME = .125f;
    private const float IMUN_TIME = .8f;

    private SpriteRenderer sR;
    private HealthBar healthBar;
    private Animator animator;
    private PlayerMovement pM;

    private void Awake()
    {
        this.currentHealth = this.maxHealth;
        this.healthBar = GameObject.FindGameObjectWithTag("Health").GetComponent<HealthBar>();
        this.healthBar.initHealth(this.currentHealth);
        this.sR = gameObject.GetComponent<SpriteRenderer>();
        this.animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        this.pM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) //test
            takeDamage(60);
    }

    private void die()
    {

        this.pM.unMoveble();
        this.currentHealth = 0;
        this.healthBar.setHealth(this.currentHealth);
        this.animator.SetTrigger("isDied");
        GameOverManager.getGameOverManager().showSceen();
        if (CurrentSceneManager.getCurrentSceneManager().getHasPlayer())
            GameOToNotDestroy.getGameOToNotDestroy().moveGOToNotDestroy();
    }

    public void revive()
    {
        this.currentHealth = maxHealth;
        this.healthBar.setHealth(this.currentHealth);
        StartCoroutine(waitForThenMove());
    }

    public void takeDamage(int amount)
    {
        if (!isImun)
        {
            if (currentHealth - amount > 0)
            {
                currentHealth -= amount;
                this.healthBar.setHealth(this.currentHealth);
                StartCoroutine(imunityTime());
                StartCoroutine(imunity());
            }
            else
                die();
        }
    }
    private IEnumerator waitForThenMove()
    {
        yield return new WaitForSeconds(.0625f);
        this.pM.moveble();
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
