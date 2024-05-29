using UnityEngine;
using UnityEngine.UI;

public class LoseBorder : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private Button _firstKitBtn;
    [SerializeField] private GameObject _useBonus;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            _losePanel.SetActive(true);
            int _kitCount = PlayerPrefs.GetInt("FirstAidKit", 0);
            if (_kitCount > 0)
            {
                _firstKitBtn.enabled = true;
                _useBonus.SetActive(true);
            }
            else
            {
                _firstKitBtn.enabled = false;
                _useBonus.SetActive(false);

            }
        }
    }
}
