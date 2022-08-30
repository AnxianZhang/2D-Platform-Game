using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settgins : MonoBehaviour
{
    public AudioMixer mixer;
    private Resolution[] resolutions;
    public Dropdown dropdown;

    private void Start()
    {
        this.resolutions = Screen.resolutions;
        initDropDown();
    }

    private void initDropDown()
    {
        this.dropdown.ClearOptions();
        List<string> options = new List<string>();

        foreach(Resolution r in this.resolutions)
            options.Add(r.width + "x" + r.height);

        options.Reverse();

        this.dropdown.AddOptions(options);
    }

    public void setVolume(float amount)
    {
        this.mixer.SetFloat("Volume", amount);
    }

    public void setFullScreen(bool state)
    {
        Screen.fullScreen = state;
        Debug.Log(state);
    }
}
