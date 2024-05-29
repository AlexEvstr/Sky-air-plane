using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuVibro : MonoBehaviour
{
    [SerializeField] private GameObject _vibroOn;
    [SerializeField] private GameObject _vibroOff;
    public static bool CanVibro;

    private void Start()
    {
        Vibration.Init();

        if (PlayerPrefs.GetInt("vibro", 1) == 1)
        {
            OnVibro();
        }

        else
        {
            OffVibro();
        }
    }

    public void OffVibro()
    {
        _vibroOn.SetActive(false);
        _vibroOff.SetActive(true);
        CanVibro = false;
        PlayerPrefs.SetInt("vibro", 0);
    }

    public void OnVibro()
    {
        _vibroOff.SetActive(false);
        _vibroOn.SetActive(true);
        CanVibro = true;
        PlayerPrefs.SetInt("vibro", 1);
    }

    public void SmallVibration()
    {
        if (CanVibro) Vibration.VibratePop();
    }

    public void StrongVibration()
    {
        if (CanVibro) Vibration.VibratePeek();
    }

    public void StandartVibration()
    {
        if (CanVibro) Vibration.Vibrate();
    }
}
