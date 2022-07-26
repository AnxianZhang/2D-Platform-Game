using UnityEngine;
using UnityEngine.Audio;

public class CurrentSceneManager : MonoBehaviour
{
    public bool hasPlayer;

    private static CurrentSceneManager instance;
    private AudioMixer audioMixer;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is already an invetory");
            return;
        }
        instance = this;
    }

    public static CurrentSceneManager getCurrentSceneManager()
    {
        return instance;
    }

    public bool getHasPlayer()
    {
        return this.hasPlayer;
    }
}
