using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class EndingManager : MonoBehaviour
{
    public GameObject endingPanel;    // Panel untuk menampilkan ending
    public GameObject epilogPanel;    // Panel untuk menampilkan ending
    public Image endingImage;        // Gambar ending
    public TextMeshProUGUI endingText;          // Teks ending
    public AudioSource audioSource;  // AudioSource untuk narasi

    public Sprite goodEndImage;      // Gambar untuk Good Ending
    public Sprite badEndImage;       // Gambar untuk Bad Ending

    public string goodEndText;       // Teks untuk Good Ending
    public string badEndText;        // Teks untuk Bad Ending

    public AudioClip goodEndAudio;   // Narasi audio untuk Good Ending
    public AudioClip badEndAudio;    // Narasi audio untuk Bad Ending

    public bool isGoodEnd;           // Kondisi untuk Good Ending
    public bool isBadEnd;            // Kondisi untuk Bad Ending

    private void Start()
    {
        isGoodEnd = false;
        isBadEnd = false;
        endingPanel.SetActive(false);
        epilogPanel.SetActive(false);
    }
    public void GameWin(string ending)
    {
        StartCoroutine(PlayEnding());

        if (ending == "Good")
        {
            isGoodEnd = true;
        }
        else if (ending == "Bad")
        {
            isBadEnd = true;
        }

        epilogPanel.SetActive(true);
    }

    private IEnumerator PlayEnding()
    {
        // Tentukan data berdasarkan ending
        if (isGoodEnd)
        {
            endingImage.sprite = goodEndImage;
            endingText.text = goodEndText;
            audioSource.clip = goodEndAudio;
        }
        else if (isBadEnd)
        {
            endingImage.sprite = badEndImage;
            endingText.text = badEndText;
            audioSource.clip = badEndAudio;
        }

        // Tampilkan gambar dan teks
        endingImage.gameObject.SetActive(true);
        endingText.gameObject.SetActive(true);

        // Mainkan narasi audio
        audioSource.Play();

        // Tunggu hingga audio selesai diputar
        yield return new WaitForSeconds(audioSource.clip.length);

        // Tampilkan ending panel
        endingPanel.SetActive(true);
    }
}
