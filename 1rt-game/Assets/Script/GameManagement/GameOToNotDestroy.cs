using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOToNotDestroy : MonoBehaviour
{
    public GameObject [] toNotDestroy;
    private static GameOToNotDestroy instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is already an GameOToNotDestroy");
            return;
        }
        instance = this;

        foreach (GameObject gO in this.toNotDestroy)
            DontDestroyOnLoad(gO);
    }

    public static GameOToNotDestroy getGameOToNotDestroy()
    {
        return instance;
    }

    public void moveGOToNotDestroy()
    {
        foreach (GameObject gO in this.toNotDestroy)
            SceneManager.MoveGameObjectToScene(gO, SceneManager.GetActiveScene());
    }
}
