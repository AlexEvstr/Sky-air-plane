using UnityEngine;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject _levelsPanel;
    [SerializeField] private GameObject _privacyWindow;
    [SerializeField] private GameObject _tutorialWindow;
    [SerializeField] private TMP_Text _coinsText;

    public static int CoinsCount;

    private void Start()
    {
        Time.timeScale = 1;
        CoinsCount = PlayerPrefs.GetInt("Coins", 0);
        _coinsText.text = CoinsCount.ToString();
    }

    public void Playbtn()
    {
        _levelsPanel.SetActive(true);
    }

    public void CloseLevels()
    {
        _levelsPanel.SetActive(false);
    }

    public void OpenPrivacy()
    {
        _privacyWindow.SetActive(true);
    }

    public void ClosePrivacy()
    {
        _privacyWindow.SetActive(false);
    }

    public void OpenTutorial()
    {
        _tutorialWindow.SetActive(true);
    }

    public void CloseTutorial()
    {
        _tutorialWindow.SetActive(false);
    }

    private void Update()
    {
        _coinsText.text = CoinsCount.ToString();
    }
}
