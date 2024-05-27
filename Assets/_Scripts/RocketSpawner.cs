using System.Collections;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    public GameObject rocketPrefab;
    public GameObject crosshairPrefab;
    public float crosshairLifetime = 0.5f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 tapPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tapPosition.z = 0;
            SpawnRocket(tapPosition);
            StartCoroutine(SpawnCrosshair(tapPosition));
        }
    }

    void SpawnRocket(Vector3 targetPosition)
    {
        Vector3 spawnPosition = new Vector3(0, -4, 0);
        GameObject rocket = Instantiate(rocketPrefab, spawnPosition, Quaternion.identity);
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
