using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FirstAidKitBtnGame : MonoBehaviour
{
    [SerializeField] private TMP_Text _kitCountText;
    [SerializeField] private GameObject _losePanel;
    private int _kitCount;

    private void Start()
    {
        _kitCount = PlayerPrefs.GetInt("FirstAidKit", 0);
        _kitCountText.text = _kitCount.ToString();
        gameObject.GetComponent<Button>().enabled = false;
    }

    public void UseKit()
    {
        if (_kitCount > 0)
        {
            _kitCount--;
            PlayerPrefs.SetInt("FirstAidKit", _kitCount);
            _kitCountText.text = _kitCount.ToString();
            KitBehavior();
        }
    }

    private void KitBehavior()
    {
        _losePanel.SetActive(false);
        GameObject plane = GameObject.FindGameObjectWithTag("Plane");
        plane.transform.position = new Vector2(13, 0);
        plane.SetActive(true);
        gameObject.GetComponent<Button>().enabled = false;
    }
}
