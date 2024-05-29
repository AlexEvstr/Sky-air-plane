using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject _levelsPanel;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void Playbtn()
    {
        _levelsPanel.SetActive(true);
    }
}
