using UnityEngine;

public class GameVibro : MonoBehaviour
{
    public static bool CanVibro;

    private void Start()
    {
        Vibration.Init();

        if (PlayerPrefs.GetInt("vibro", 1) == 1)
        {
            CanVibro = true;
            PlayerPrefs.SetInt("vibro", 1);
        }

        else
        {
            CanVibro = false;
            PlayerPrefs.SetInt("vibro", 0);
        }
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
