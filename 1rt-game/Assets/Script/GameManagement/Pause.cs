using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPaused = false;
    private GameObject pauseMenu;
    private PlayerMovement pM;

    private void Start()
    {
        this.pM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        this.pauseMenu = GameObject.FindGameObjectWithTag("Pause");
        this.pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            if (!this.isPaused)
                pause();
            else
                resume();
    }

    private void pause()
    {
        this.isPaused = true;
        this.pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    private void resume()
    {
        this.isPaused = false;
        this.pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
