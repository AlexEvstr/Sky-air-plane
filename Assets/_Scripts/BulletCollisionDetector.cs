using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionDetector : MonoBehaviour
{
    [SerializeField] private GameObject _normalHit;
    [SerializeField] private GameObject _lastHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            GameObject normalHit = Instantiate(_normalHit);
            normalHit.transform.position = new Vector2((collision.transform.position.x + transform.position.x) / 2, (collision.transform.position.y + transform.position.y) / 2);
            Destroy(normalHit, 0.4f);
            
            PlaneHP.CurrentHp -= 0.1f;

            if (PlaneHP.CurrentHp <= 0)
            {
                GameObject lastHit = Instantiate(_lastHit);
                lastHit.transform.position = collision.transform.position;
                Destroy(lastHit, 0.7f);
            }

            Destroy(gameObject);
        }

    }
}
