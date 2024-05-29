using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinController : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsText;
    private int _coinsCount;

    private void Start()
    {
        _coinsCount = GameManager.CurrentLevel * 100;
        _coinsText.text = $"YOU EARNED {_coinsCount} COINS!";
    }
}
