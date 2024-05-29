using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletShop : MonoBehaviour
{
    [SerializeField] private TMP_Text _bulletCountText;
    [SerializeField] private int _price;
    [SerializeField] private MenuAudio _menuAudio;
    [SerializeField] private MenuVibro _menuVibro;
    private int _bulletCount;

    private void Start()
    {
        _bulletCount = PlayerPrefs.GetInt(gameObject.name, 0);
        _bulletCountText.text = _bulletCount.ToString();
    }

    public void BuyItem()
    {
        if (_price <= MainMenuController.CoinsCount)
        {
            MainMenuController.CoinsCount -= _price;
            _bulletCount += 5;
            PlayerPrefs.SetInt(gameObject.name, _bulletCount);
            _bulletCountText.text = _bulletCount.ToString();
            PlayerPrefs.SetInt("Coins", MainMenuController.CoinsCount);
            _menuAudio.PlauBuySound();
            _menuVibro.StrongVibration();
        }
        else
        {
            _menuAudio.PlayClickSound();
            _menuVibro.SmallVibration();
        }
    }
}