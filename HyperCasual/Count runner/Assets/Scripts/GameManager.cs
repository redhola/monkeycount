using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int followerCount = 0;
    public bool isGameActive;
    public GameObject gameOverPanel;
    public Text followerCountText;
    public GameObject settingsPanel;
    public bool isGamePaused = false;
    public GameObject PauseButton;
    public GameObject FollowerText;
    public int highFollowerCount = 0; 
    public Text highFollowerCountText;
    public GameObject levelCompletePanel;
    public Text LvEndingCountText;


    private void Awake()
    {
        if (Instance != null && Instance != this)
    {
        Destroy(gameObject); // Destroy the new duplicate that was created on scene load
        return;
    }
    
    Instance = this;
    }


    private void Start()
    {
        isGameActive = true;
        Time.timeScale = 1;
        UpdateHighFollowerCountText();
        UpdateFollowerCountText();
    }
    

    public void ToggleSettingsPanel()
    {
        isGamePaused = !isGamePaused;
        settingsPanel.SetActive(isGamePaused);
        Time.timeScale = isGamePaused ? 0 : 1; 
    }

    public void LevelComplete()
    {
        Debug.Log("Level Complete!");
        levelCompletePanel.SetActive(true);
        isGameActive = false;
        PauseButton.SetActive(false);
        FollowerText.SetActive(false);
        Time.timeScale = 0;

    }

    public void LoseFollower(int amount)
    {
        if (isGameActive)
        {
            followerCount -= amount;
            UpdateFollowerCountText();
            CheckGameOver();
            UpdateLvEndingCountText();
        }
    }


    public void GainFollower(int amount)
    {
        if (isGameActive)
        {
            followerCount += amount;
            UpdateFollowerCountText();
            UpdateLvEndingCountText();
            UpdateHighFollowerCountText();
        }
    }


    private void UpdateFollowerCountText()
    {
        if (followerCountText != null)
        {
            followerCountText.text = "Followers: " + followerCount;
        }
    }


    private void UpdateHighFollowerCountText()
    {
        if (followerCount > highFollowerCount)
        {
            highFollowerCount = followerCount;
            Debug.Log(highFollowerCount);
            highFollowerCountText.text = "You've earned " + highFollowerCount + " followers this round";            
        }
    }

    private void UpdateLvEndingCountText()
    {
        if (LvEndingCountText != null)
        {
            LvEndingCountText.text = "You've survived with " + followerCount + " followers this round";
        }
    }


    private void CheckGameOver()
    {
        if (followerCount <= 0)
        {
            GameOver();
        }
    }


    private void GameOver()
    {
        isGameActive = false;
        gameOverPanel.SetActive(true);
        PauseButton.SetActive(false);
        FollowerText.SetActive(false);
        Time.timeScale = 0;
    }


    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // Time.timeScale = 1; // Resume the game time.
        // isGameActive = true; // Set the game as active again.
        // followerCount = 0; // Reset follower count.
        // UpdateFollowerCountText(); // Update the text display.
        // gameOverPanel.SetActive(false); // Make sure to deactivate the game over panel.
        // isGamePaused = false; // Ensure the game is not paused.
        // highFollowerCountText = GameObject.Find("HighFollowerCountText").GetComponent<Text>();
    }
}
