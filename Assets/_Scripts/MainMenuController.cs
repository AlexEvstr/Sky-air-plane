using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject _levelsPanel;
    [SerializeField] private GameObject _privacyWindow;
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

    public void OpenPrivacy()
    {
        _privacyWindow.SetActive(true);
    }

    public void ClosePrivacy()
    {
        _privacyWindow.SetActive(false);
    }

    private void Update()
    {
        _coinsText.text = CoinsCount.ToString();
    }
}
