using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settgins : MonoBehaviour
{
    private Resolution[] resolutions;
    private GameObject settings;
    public Dropdown dropdown;
    public AudioMixer mixer;

    private void Start()
    {
        this.settings = GameObject.FindGameObjectWithTag("Settings");
        this.resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        initDropDown();
    }

    private void initDropDown()
    {
        this.dropdown.ClearOptions();
        List<string> options = new List<string>();

        foreach(Resolution r in this.resolutions)
            options.Add(r.width + "x" + r.height);

        //options.Reverse();

        this.dropdown.AddOptions(options);
        this.dropdown.value = options.Count - 3; // --> with the Reverse the max resolution is the first one
        setResolution(this.dropdown.value);
        this.dropdown.RefreshShownValue();

        Screen.fullScreen = false;
    }

    public void setResolution(int resolutionIdx)
    {
        Screen.SetResolution(this.resolutions[resolutionIdx].width, this.resolutions[resolutionIdx].height, Screen.fullScreen);
    }

    public void setVolume(float amount)
    {
        this.mixer.SetFloat("Volume", amount);
    }

    public void setFullScreen(bool state)
    {
        Screen.fullScreen = state;
    }

    public void closeSettingsButton()
    {
        this.settings.SetActive(false);
    }
}
