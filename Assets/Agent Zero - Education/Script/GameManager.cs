using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    public int totalTrash; // Total number of trash items in the level
    private int correctlySortedTrash = 0; // Counter for correctly sorted trash
    private int incorrectlySortedTrash = 0; // Counter for incorrectly sorted trash

    [Header("UI Elements")]
    public Text correctText; // Text UI to display correct sorting count
    public Text incorrectText; // Text UI to display incorrect sorting count
    public GameObject resultPanel; // Panel to display the result
    public Text resultText; // Text to display the result summary

    [Header("Timer Settings")]
    public float levelDuration = 120f; // Time limit for the level
    public Text timerText; // UI Text for the timer

    private bool gameEnded = false;
    public static GameManager Instance; // Instance singleton
    void Awake()
    {
        // Menyimpan referensi GameManager
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Enum untuk tipe sampah
    public enum TrashType
    {
        Organic,
        Recyclable,
        Hazardous
    }

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        if (!gameEnded)
        {
            levelDuration -= Time.deltaTime;
            //UpdateTimerUI();

            if (levelDuration <= 0)
            {
                EndGame(false); // Time's up, end the game
            }
        }
    }

    public void RegisterTrashSorting(bool isCorrect)
    {
        if (isCorrect)
        {
            correctlySortedTrash++;
        }
        else
        {
            incorrectlySortedTrash++;
        }

        UpdateUI();

        if (correctlySortedTrash + incorrectlySortedTrash >= totalTrash)
        {
            EndGame(true); // All trash has been sorted
        }
    }

    private void UpdateUI()
    {
        correctText.text = "Correct: " + correctlySortedTrash;
        incorrectText.text = "Incorrect: " + incorrectlySortedTrash;
    }

    private void UpdateTimerUI()
    {
        timerText.text = "Time Left: " + Mathf.Ceil(levelDuration) + "s";
    }
    public void Win()
    {
        EndGame(true);
    }

    private void EndGame(bool allTrashSorted)
    {
        gameEnded = true;

        // Show result panel
        resultPanel.SetActive(true);

        if (allTrashSorted)
        {
            resultText.text = "Mission Accomplished!\n" +
                             "Correctly Sorted: " + correctlySortedTrash + "\n" +
                             "Incorrectly Sorted: " + incorrectlySortedTrash;
        }
        else
        {
            resultText.text = "Time's Up!\n" +
                             "Correctly Sorted: " + correctlySortedTrash + "\n" +
                             "Incorrectly Sorted: " + incorrectlySortedTrash;
        }
    }
}
