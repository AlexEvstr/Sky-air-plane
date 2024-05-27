using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    private float movementSpeed = 2.0f;
    private Vector2 _startPosition;
    private float _backgroundCenter;

    private void Start()
    {
        _startPosition = transform.position;
        _backgroundCenter = GetComponent<BoxCollider2D>().size.x / 2;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * Time.deltaTime * movementSpeed);
        if (transform.position.x < (_startPosition.x - _backgroundCenter)) transform.position = _startPosition;
    }
}