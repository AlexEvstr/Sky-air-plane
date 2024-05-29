using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelCompleteText;
    [SerializeField] private GameObject _pausePanel;
    public static int CurrentLevel;

    private void Start()
    {
        Time.timeScale = 1;
        CurrentLevel = PlayerPrefs.GetInt("Level", 1);
        _levelCompleteText.text = $"LEVEL {CurrentLevel} COMPLETE!";
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        _pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        _pausePanel.SetActive(false);
    }

    public void MenuBtn()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameplayScene");
    }
}