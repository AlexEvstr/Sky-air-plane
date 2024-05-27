using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            Destroy(gameObject);
            PlaneHP.CurrentHp -= 0.1f;
        }

    }
}
