using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjtManager : MonoBehaviour
{
    private GameObject gameOverSceen;
    private static GameObjtManager instance;

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
        this.gameOverSceen = GameObject.FindGameObjectWithTag("GameOver");
        if (gameOverSceen == null)
        {
            Debug.Log("non");
            return;
        }
        this.gameOverSceen.SetActive(false);
    }

    public static GameObjtManager getGameObjtManager()
    {
        return instance;
    }

    public void showSceen()
    {
        this.gameOverSceen.SetActive(true);
    }
}
