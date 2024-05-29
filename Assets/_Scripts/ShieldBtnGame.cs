using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBtnGame : MonoBehaviour
{
    [SerializeField] private TMP_Text _shieldCountText;
    [SerializeField] private GameObject _shield;
    [SerializeField] private GameObject _lose;
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _win;
    private int _shieldCount;

    private void Start()
    {
        _shieldCount = PlayerPrefs.GetInt("Shield", 0);
        _shieldCountText.text = _shieldCount.ToString();
    }

    public void UseShield()
    {
        if (_shieldCount > 0 && !_shield.activeInHierarchy)
        {
            _shieldCount--;
            PlayerPrefs.SetInt("Shield", _shieldCount);
            _shieldCountText.text = _shieldCount.ToString();
            ShieldBehavior();
        }
    }

    private void ShieldBehavior()
    {
        _shield.SetActive(true);
    }

    private void Update()
    {
        if (_lose.activeInHierarchy || _pause.activeInHierarchy || _win.activeInHierarchy)
        {
            gameObject.GetComponent<Button>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<Button>().enabled = true;
        }
    }
}
