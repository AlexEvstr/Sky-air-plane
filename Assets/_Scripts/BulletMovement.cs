using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * Time.deltaTime * 10f);
    }
}
