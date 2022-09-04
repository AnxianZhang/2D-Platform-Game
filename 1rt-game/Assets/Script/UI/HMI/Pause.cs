using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPaused = false;
    private GameObject pauseMenu;
    private PlayerMovement pM;
    private GameObject setting;

    private void Start()
    {
        this.pM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        this.pauseMenu = GameObject.FindGameObjectWithTag("Pause");
        this.pauseMenu.SetActive(false);

        this.setting = GameObject.FindGameObjectWithTag("Settings");
        this.setting.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            if (!this.isPaused) pause(); 
            else resumeButton();
    }

    private void pause()
    {
        this.isPaused = true;
        this.pauseMenu.SetActive(true);
        this.pM.unMoveble();
        Time.timeScale = 0;
    }

    public void resumeButton()
    {
        this.isPaused = false;
        this.pauseMenu.SetActive(false);
        this.pM.moveble();
        Time.timeScale = 1;
    }

    public void menuButton()
    {
        resumeButton();
        GameOverManager.getGameOverManager().menuButton();
    }

    public void settingsButton()
    {
        this.setting.SetActive(true);
    }
}
