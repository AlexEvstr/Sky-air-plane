using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletGameButton : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _bullet; 
    [SerializeField] private Sprite _newBulletSprite;
    [SerializeField] private float _hitPower;
    [SerializeField] private GameObject _colorMark;
    [SerializeField] private TMP_Text _bulletCountText;
    [SerializeField] private GameObject _firstBullet;

    private int _bulletCount;

    public void ChooseBullet()
    {
        PlayerPrefs.SetFloat("HitPower", _hitPower);

        _colorMark.transform.SetParent(transform);
        _bullet.sprite = _newBulletSprite;
    }

    private void Update()
    {
        _bulletCount = PlayerPrefs.GetInt(gameObject.name, 0);
        if (gameObject.name == "bullet_0")
        {
            _bulletCount = 999;
        }

        if (_bulletCount <= 0)
        {
            _bulletCount = 0;
            GetComponent<Button>().enabled = false;
            if (gameObject.transform.childCount == 3)
            {
                _colorMark.transform.SetParent(_firstBullet.transform);
            }
        }
        else
        {
            GetComponent<Button>().enabled = true;
        }

        if (gameObject.name == "bullet_0")
        {
            _bulletCountText.text = 999.ToString();
        }
        else _bulletCountText.text = _bulletCount.ToString();

        if (gameObject.transform.childCount == 3)
        {
            gameObject.GetComponent<Image>().color = Color.red;
            ChooseBullet();
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
        }
    }
}
