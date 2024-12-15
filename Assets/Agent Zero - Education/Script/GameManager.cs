using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    public int totalTrash; // Total number of trash items in the level
    public int trashCollected = 0; // Counter for collected trash

    [Header("Timer Settings")]
    public float levelDuration; // Time limit for the level
    private float CurrlevelDuration; // Time limit for the level
    public TextMeshProUGUI timerText; // UI Text for the timer
    public GameObject Timer_Panel;
    public Slider timerSlider;
    public Slider timerSlider2;
    public GameObject gameBarrier;

    [Header("Stage 3 Settings")]
    public GameObject alphaChangingObject; // Object that changes alpha
    public GameObject[] colorChangingObjects; // Array of objects that change color
    public Color startColor = Color.gray;
    public Color endColor = Color.blue;
    public float colorChangeSpeed = 0.1f;

    public bool levelStarted = false;
    public bool gameEnded = false;
    public float currentAlpha = 0f;

    private Renderer alphaObjectRenderer;

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
        Time.timeScale = 1f;
        Timer_Panel.SetActive(false);
        totalTrash = 0;
        trashCollected = 0;
        currentAlpha = 0f;
        CurrlevelDuration = levelDuration;
        WaterWall.SetActive(true);
        gameBarrier.SetActive(true);
        levelStarted = false;
        gameEnded = false;
        ending = "";

        if (alphaChangingObject != null)
        {
            alphaObjectRenderer = alphaChangingObject.GetComponent<Renderer>();
            alphaObjectRenderer.material.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
        }

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

        sliderFill = 0;
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
    } 

    public void StartLevel()
    {
        levelStarted = true;
        Timer_Panel.SetActive(true);
    }

    public void RegisterTrashSorting()
    {
        if (levelStarted)
        {
            trashCollected++;
        }

        if (gameEnded)
        {
            trashCollected++;
            currentAlpha = Mathf.Clamp(trashCollected * 10, 0f, 1f);
            Color currentColor = alphaObjectRenderer.material.color;
            alphaObjectRenderer.material.color = new Color(currentColor.r, currentColor.g, currentColor.b, currentAlpha);

            if (trashCollected > 10)
            {
                ending = "good";
            }
            else
            {
                ending = "bad";
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

    private void EndGame()
    {
        gameEnded = true;
        WaterWall.SetActive(false);
        gameBarrier.SetActive(false);
        Timer_Panel.SetActive(false);
        Debug.Log("Level Completed. Trash Collected: " + trashCollected);
    }

    public EndingManager endingManager;
    public void Win()
    {
        endingManager.GameWin(ending);
    }
}
