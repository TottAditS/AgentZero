using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject SettingsPanel;
    public GameObject TutorialPanel;
    public Slider volumeSlider;

    void Start()
    {
        MainPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        TutorialPanel.SetActive(false);
        if (volumeSlider != null)
        {
            volumeSlider.value = 1;
        }
    }

    public void StartGame()
    {
        MainPanel.SetActive(false);
        TutorialPanel.SetActive(true);
    }

    public void OpenSettings()
    {
        MainPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        MainPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Education");
    }

    public void SetVolume()
    {
        if (volumeSlider != null)
        {
            SoundManager.instance.SetMasterVolume(volumeSlider.value);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
