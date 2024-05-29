using TMPro;
using UnityEngine;

public class ShieldShop : MonoBehaviour
{
    [SerializeField] private TMP_Text _shieldCountText;
    [SerializeField] private int _shieldPrice;
    [SerializeField] MenuAudio _menuAudio;
    private int _shieldCount;

    private void Start()
    {
        _shieldCount = PlayerPrefs.GetInt("Shield", 0);
        _shieldCountText.text = _shieldCount.ToString();
    }

    public void BuyItem()
    {
        if (_shieldPrice <= MainMenuController.CoinsCount)
        {
            MainMenuController.CoinsCount -= _shieldPrice;
            _shieldCount++;
            PlayerPrefs.SetInt("Shield", _shieldCount);
            _shieldCountText.text = _shieldCount.ToString();
            PlayerPrefs.SetInt("Coins", MainMenuController.CoinsCount);
            _menuAudio.PlauBuySound();
        }
        else
        {
            _menuAudio.PlayClickSound();
        }
    }
}