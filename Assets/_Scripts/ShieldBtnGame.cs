using TMPro;
using UnityEngine;

public class ShieldBtnGame : MonoBehaviour
{
    [SerializeField] private TMP_Text _shieldCountText;
    private int _shieldCount;

    private void Start()
    {
        _shieldCount = PlayerPrefs.GetInt("Shield", 0);
        _shieldCountText.text = _shieldCount.ToString();
    }

    public void UseShield()
    {
        if (_shieldCount > 0)
        {
            _shieldCount--;
            PlayerPrefs.SetInt("Shield", _shieldCount);
            _shieldCountText.text = _shieldCount.ToString();
        }
    }
}
