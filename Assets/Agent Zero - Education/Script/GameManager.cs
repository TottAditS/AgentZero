using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    public int trashCollected = 0; // Counter for collected trash

    [Header("Timer Settings")]
    public float levelDuration; // Time limit for the level
    private float CurrlevelDuration; // Time limit for the level
    public TextMeshProUGUI timerText; // UI Text for the timer
    public GameObject Timer_Panel;
    public Slider timerSlider;
    public Slider timerSlider2;
    public GameObject gameBarrier;

    public bool levelStarted = false;
    public bool gameEnded = false;
    public static GameManager Instance; // Singleton instance
    public enum TrashType
    {
        Organic,
        Anorganic,
        Recyclable,
        Hazardous
    }
    void Awake()
    {
        // Initialize singleton instance
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        PMovement.enabled = true;
        Time.timeScale = 1f;
        Timer_Panel.SetActive(false);
        trashCollected = 0;
        CurrlevelDuration = levelDuration;
        WaterWall.SetActive(true);
        gameBarrier.SetActive(true);
        stage2trashbin.SetActive(true);
        levelStarted = false;
        gameEnded = false;
        ending = "";
        currentAlpha = 0f;
        sliderFill = 0;

        if (timerSlider != null)
        {
            timerSlider.maxValue = levelDuration;
            timerSlider.value = 0;
        }
        if (timerSlider2 != null)
        {
            timerSlider2.maxValue = levelDuration;
            timerSlider2.value = 0;
        }

    }

    private float sliderFill;

    void Update()
    {
        if (levelStarted && !gameEnded)
        {
            CurrlevelDuration -= Time.deltaTime;
            sliderFill += Time.deltaTime;

            UpdateTimerUI();

            if (CurrlevelDuration <= 0)
            {
                EndGame();
            }
        }

        if (tilemap != null)
        {
            Color currentColor = tilemap.color;
            tilemap.color = new Color(currentColor.r, currentColor.g, currentColor.b, currentAlpha);
        }
    } 

    public void StartLevel()
    {
        levelStarted = true;
        Timer_Panel.SetActive(true);
    }

    public Tilemap tilemap; // Drag and drop Tilemap di Inspector
    [Range(0f, 1f)] // Slider untuk mengatur nilai alpha
    public float currentAlpha = 1f; 
    public void RegisterTrashSorting()
    {
        if (levelStarted && !gameEnded)
        {
            trashCollected++;
        }

        if (gameEnded)
        {
            trashCollected++;

            currentAlpha = Mathf.Clamp(trashCollected / 10f, 0f, 1f); // Skala trashCollected ke rentang 0-1

            // Ubah alpha dari objek
            if (tilemap != null)
            {
                Color currentColor = tilemap.color;
                tilemap.color = new Color(currentColor.r, currentColor.g, currentColor.b, currentAlpha);
            }

            if (currentAlpha > 0.7)
            {
                ending = "Good";
            }
            else
            {
                ending = "Bad";
            }
        }
    }

    private string ending;

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(CurrlevelDuration / 60);
            int seconds = Mathf.FloorToInt(CurrlevelDuration % 60);
            timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }

        if (timerSlider != null)
        {
            timerSlider.value = sliderFill;
            timerSlider2.value = sliderFill;
        }
    }

    public GameObject WaterWall;
    public GameObject stage2trashbin;

    private void EndGame()
    {
        gameEnded = true;
        WaterWall.SetActive(false);
        gameBarrier.SetActive(false);
        Timer_Panel.SetActive(false);
        stage2trashbin.SetActive(false);
        Debug.Log("Level Completed. Trash Collected: " + trashCollected);
        trashCollected = 0;
    }

    public EndingManager endingManager;
    public Movement PMovement;
    public void Win()
    {
        SoundManager.Instance.StopBGM();

        if (ending == "")
        {
            ending = "Bad";
        }

        if (currentAlpha > 0.7)
        {
            ending = "Good";
        }
        else
        {
            ending = "Bad";
        }

        PMovement.enabled = false;
        endingManager.GameWin(ending);
    }
}
