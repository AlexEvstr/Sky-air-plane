using TMPro;
using UnityEngine;

public class FirtsAidKitShop : MonoBehaviour
{
    [SerializeField] private TMP_Text _firstKitCountText;
    [SerializeField] private int _kitPrice;
    [SerializeField] private MenuAudio _menuAudio;
    [SerializeField] private MenuVibro _menuVibro;
    private int _kitCount;

    private void Start()
    {
        _kitCount = PlayerPrefs.GetInt("FirstAidKit", 0);
        _firstKitCountText.text = _kitCount.ToString();
    }

    public void BuyItem()
    {
        if (_kitPrice <= MainMenuController.CoinsCount)
        {
            MainMenuController.CoinsCount -= _kitPrice;
            _kitCount++;
            PlayerPrefs.SetInt("FirstAidKit", _kitCount);
            _firstKitCountText.text = _kitCount.ToString();
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
