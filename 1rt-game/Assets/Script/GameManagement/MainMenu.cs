using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject setting;
    private void Start()
    {
        this.setting = GameObject.FindGameObjectWithTag("Settings");
        this.setting.SetActive(false);
    }
    public void startGameButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void settingsButton()
    {
        this.setting.SetActive(true);
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
