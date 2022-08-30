using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void startGameButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void settingsButton()
    {

    }

    public void quitButton()
    {
        Application.Quit();
    }
}
