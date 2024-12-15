using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject pauseMenu; // Assign your pause menu UI here

    private bool isGamePaused = false;

    void Start()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false); // Ensure pause menu is hidden initially
        }
    }

    // Toggle Pause
    public void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;
        pauseMenu.SetActive(isGamePaused);

        if (isGamePaused)
        {
            Time.timeScale = 0f; // Pause the game
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
        }
    }

    // Restart the current level
    public void RestartGame()
    {
        Time.timeScale = 1f; // Ensure game is unpaused before restarting
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Go back to the main menu
    public void BackToMainMenu()
    {
        Time.timeScale = 1f; // Ensure game is unpaused
        SceneManager.LoadScene("Menu"); // Replace "MainMenu" with the actual name of your main menu scene
    }

    // Quit the game
    public void QuitGame()
    {
        //Debug.Log("Quitting game...");
        Application.Quit();
    }
}
