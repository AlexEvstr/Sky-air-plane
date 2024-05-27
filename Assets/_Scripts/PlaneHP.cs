using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneHP : MonoBehaviour
{
    [SerializeField] private Image _hpBar;
    [SerializeField] private float _maximumHP;
    public static float CurrentHp;

    private void Start()
    {
        //_maximumHP = 1.0f;
        CurrentHp = _maximumHP;
    }

    private void Update()
    {
        _hpBar.fillAmount = CurrentHp / _maximumHP;

        if (CurrentHp <= 0)
        {
            Destroy(gameObject);
            PlaneSpawner.CanSpawnPlane = true;
        }
    }
}
