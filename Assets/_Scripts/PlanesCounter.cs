using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanesCounter : MonoBehaviour
{
    [SerializeField] private GameObject _completePanel;
    private GameAudio _gameAudio;
    public static int DestroyedPlanes;

    private void Start()
    {
        _gameAudio = GetComponent<GameAudio>();
        DestroyedPlanes = 0;
    }

    private void Update()
    {
        if (DestroyedPlanes == GameManager.CurrentLevel)
        {
            _completePanel.SetActive(true);
            _gameAudio.PlayCompleteSound();

            int coins = PlayerPrefs.GetInt("Coins", 0);
            coins += GameManager.CurrentLevel * 100;
            PlayerPrefs.SetInt("Coins", coins);

            GameManager.CurrentLevel++;

            if (GameManager.CurrentLevel > PlayerPrefs.GetInt("BestLevel", 1))
            {
                PlayerPrefs.SetInt("BestLevel", GameManager.CurrentLevel);
            }

            PlayerPrefs.SetInt("Level", GameManager.CurrentLevel);
            
            DestroyedPlanes = 0;
        }
    }
}
