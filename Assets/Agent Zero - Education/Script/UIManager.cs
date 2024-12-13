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

    [Header("Prologue")]
    public GameObject prologuePanel;
    public Image prologueImage;
    public Sprite[] prologueSprites; 
    public AudioClip[] prologueNarration; 
    public float imageDisplayTime = 5f;
    private AudioSource narrationSource;


    void Start()
    {
        MainPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        TutorialPanel.SetActive(false);
        prologuePanel.SetActive(false);
        narrationSource = gameObject.AddComponent<AudioSource>();
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

    public void PanelTutorialClicked()
    {
        TutorialPanel.SetActive(false);
        StartCoroutine(Prologue());
    }

    private IEnumerator Prologue()
    {
        prologuePanel.SetActive(true);
        for (int i = 0; i < prologueSprites.Length; i++)
        {
            prologueImage.sprite = prologueSprites[i];
            if (i < prologueNarration.Length && prologueNarration[i] != null)
            {
                narrationSource.clip = prologueNarration[i];
                narrationSource.Play();
            }
            if (narrationSource.isPlaying)
            {
                yield return new WaitForSeconds(Mathf.Max(imageDisplayTime, narrationSource.clip.length));
            }
            else
            {
                yield return new WaitForSeconds(imageDisplayTime);
            }
        }
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
