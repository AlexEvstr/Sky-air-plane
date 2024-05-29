using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionDetector : MonoBehaviour
{
    [SerializeField] private GameObject _normalHit;
    [SerializeField] private GameObject _lastHit;
    [SerializeField] private AudioClip _lastHitSound;
    [SerializeField] private AudioClip _normalHitSound;
    private AudioSource _audioSource;

    private float _hitPower;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _hitPower = PlayerPrefs.GetFloat("HitPower", 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            GameObject normalHit = Instantiate(_normalHit);
            normalHit.transform.position = new Vector2((collision.transform.position.x + transform.position.x) / 2, (collision.transform.position.y + transform.position.y) / 2);
            Destroy(normalHit, 0.4f);
            
            PlaneHP.CurrentHp -= _hitPower;

            if (PlaneHP.CurrentHp <= 0)
            {
                GameObject lastHit = Instantiate(_lastHit);
                lastHit.transform.position = collision.transform.position;
                Destroy(lastHit, 0.7f);
                PlayLastHitSound();
            }
            else
            {
                PlayNormalHitSound();
            }

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<TrailRenderer>().enabled = false;
            Destroy(gameObject, 2);
        }
    }

    private void PlayLastHitSound()
    {
        _audioSource.PlayOneShot(_lastHitSound);
    }

    private void PlayNormalHitSound()
    {
        _audioSource.PlayOneShot(_normalHitSound);
    }
}
