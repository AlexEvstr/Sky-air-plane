using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float verticalSpeed = 10f;
    [SerializeField] private float yMin = -3f;
    [SerializeField] private float yMax = 3f;

    private bool movingUp = true;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (movingUp)
        {
            transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime);
            if (transform.position.y >= yMax)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.Translate(Vector3.down * verticalSpeed * Time.deltaTime);
            if (transform.position.y <= yMin)
            {
                movingUp = true;
            }
        }
    }
}