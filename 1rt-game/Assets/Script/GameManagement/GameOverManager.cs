using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    private GameObject gameOverSceen;
    private PlayerHealth pH;
    private static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is already an gom");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        this.pH = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        this.gameOverSceen = GameObject.FindGameObjectWithTag("GameOver");
        this.gameOverSceen.SetActive(false);
    }

    public static GameOverManager getGameOverManager()
    {
        return instance;
    }

    public void showSceen()
    {
        this.gameOverSceen.SetActive(true);
    }

    public void restartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // laod active scene, enable by getting the scene idx
        this.pH.revive();
        this.gameOverSceen.SetActive(false);
        Inventory.getInventory().laodNbCoinsBeforeEnteringInScene();
    }

    public void menuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
