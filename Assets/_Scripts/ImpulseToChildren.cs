using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseToChildren : MonoBehaviour
{
    private float impulseForce = 5f;
    private float minRotationSpeed = 80f;
    private float maxRotationSpeed = 150f;

    private void Start()
    {
        ApplyImpulseToChildren();
        AddRotationToChildren();
    }

    private void ApplyImpulseToChildren()
    {
        foreach (Transform child in transform)
        {
            Rigidbody2D rb = child.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = (child.position - transform.position).normalized;
                rb.AddForce(direction * impulseForce, ForceMode2D.Impulse);
            }
        }
    }

    private void AddRotationToChildren()
    {
        foreach (Transform child in transform)
        {
            float rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
            if (Random.value > 0.5f)
            {
                rotationSpeed = -rotationSpeed; // Рандомное направление вращения
            }

            Rotator rotator = child.gameObject.AddComponent<Rotator>();
            rotator.rotationSpeed = rotationSpeed;
        }
    }
}

public class Rotator : MonoBehaviour
{
    public float rotationSpeed;

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}