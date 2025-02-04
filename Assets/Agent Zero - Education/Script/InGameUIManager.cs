using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject pauseMenu; // Assign your pause menu UI here
    public GameObject mobileButtonsPanel; // Panel untuk mobile buttons
    public Toggle mobileToggle; // Toggle UI dari Inspector


    private bool isGamePaused = false;

    void Start()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false); // Ensure pause menu is hidden initially
        }
        if (mobileToggle != null)
        {
            mobileButtonsPanel.SetActive(mobileToggle.isOn);
            mobileToggle.onValueChanged.AddListener(ToggleMobilePanel);
        }
        else
        {
            Debug.LogWarning("Toggle reference is missing!");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseGame();
        }
    }
    private void ToggleMobilePanel(bool isActive)
    {
        if (mobileButtonsPanel != null)
        {
            mobileButtonsPanel.SetActive(isActive);
        }
        else
        {
            Debug.LogWarning("Mobile Buttons Panel reference is missing!");
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
