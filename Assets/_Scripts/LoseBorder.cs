using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseBorder : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            _losePanel.SetActive(true);
            collision.gameObject.SetActive(false);
        }
    }
}
