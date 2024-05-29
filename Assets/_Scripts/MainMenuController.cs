using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject _levelsPanel;
    [SerializeField] private TMP_Text _coinsText;

    private void Start()
    {
        Time.timeScale = 1;
        int coins = PlayerPrefs.GetInt("Coins", 0);
        _coinsText.text = coins.ToString();
    }

    public void Playbtn()
    {
        _levelsPanel.SetActive(true);
    }
}
