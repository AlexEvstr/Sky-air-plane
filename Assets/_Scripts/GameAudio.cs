using UnityEngine;

public class GameAudio : MonoBehaviour
{
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private AudioClip _completeSound;
    [SerializeField] private AudioClip _gameOverSound;
    
    [SerializeField] private AudioClip _shootSound;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayClickSound()
    {
        _audioSource.PlayOneShot(_clickSound);
    }

    public void PlayCompleteSound()
    {
        _audioSource.PlayOneShot(_completeSound);
    }

    public void PlayGameOverSound()
    {
        _audioSource.PlayOneShot(_gameOverSound);
    }

    public void PlayShootSound()
    {
        _audioSource.PlayOneShot(_shootSound);
    }
}