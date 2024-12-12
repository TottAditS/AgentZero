using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject SettingsPanel;
    public GameObject TutorialPanel;

    void Start()
    {
        MainPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        TutorialPanel.SetActive(false);
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

    public void QuitGame()
    {
        Application.Quit();
    }
}
