using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RocketSpawner : MonoBehaviour
{
    public GameObject rocketPrefab;
    public GameObject crosshairPrefab;
    public float crosshairLifetime = 0.5f;
    private GameAudio _gameAudio;

    private void Start()
    {
        _gameAudio = GetComponent<GameAudio>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsPointerOverUIElement())
            {
                return;
            }
            _gameAudio.PlayShootSound();
            if (GameVibro.CanVibro) Vibration.VibratePop();
            Vector3 tapPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tapPosition.z = 0;
            SpawnRocket(tapPosition);
            StartCoroutine(SpawnCrosshair(tapPosition));
        }
    }

    private bool IsPointerOverUIElement()
    {
        // Check if the pointer is over a UI element
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        return results.Count > 0;
    }

    void SpawnRocket(Vector3 targetPosition)
    {
        Vector3 spawnPosition = new Vector3(0, -4, 0);
        GameObject rocket = Instantiate(rocketPrefab, spawnPosition, Quaternion.identity);

        int bullets = PlayerPrefs.GetInt(rocket.GetComponent<SpriteRenderer>().sprite.name, 0);
        bullets--;
        PlayerPrefs.SetInt(rocket.GetComponent<SpriteRenderer>().sprite.name, bullets);

        Vector3 direction = targetPosition - spawnPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rocket.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    IEnumerator SpawnCrosshair(Vector3 position)
    {
        GameObject crosshair = Instantiate(crosshairPrefab, position, Quaternion.identity);
        SpriteRenderer crosshairRenderer = crosshair.GetComponent<SpriteRenderer>();
        Color originalColor = crosshairRenderer.color;
        float elapsedTime = 0f;

        while (elapsedTime < crosshairLifetime)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / crosshairLifetime);
            crosshairRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        Destroy(crosshair);
    }
}
