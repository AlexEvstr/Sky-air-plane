using UnityEngine;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject _levelsPanel;
    [SerializeField] private GameObject _privacyWindow;
    [SerializeField] private GameObject _tutorialWindow;
    [SerializeField] private TMP_Text _coinsText;
    [SerializeField] private GameObject _onboard_1;
    [SerializeField] private GameObject _onboard_2;
    [SerializeField] private GameObject _onboard_3;

    public static int CoinsCount;

    private void Start()
    {
        Time.timeScale = 1;
        if (PlayerPrefs.GetString("EnterIsNotFirst", "") == "")
        {
            _onboard_1.SetActive(true);
        }
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

    public void Goto2()
    {
        _onboard_1.SetActive(false);
        _onboard_2.SetActive(true);
    }

    public void Goto3()
    {
        _onboard_2.SetActive(false);
        _onboard_3.SetActive(true);
    }

    public void GotoGame()
    {
        _onboard_3.SetActive(false);
        PlayerPrefs.SetString("EnterIsNotFirst", "really");
    }

}