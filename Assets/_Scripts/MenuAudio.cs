using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    [SerializeField] private GameObject _musicOn; 
    [SerializeField] private GameObject _musicOff;
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private AudioClip _buySound;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.GetString("audio", "") == "off")
        {
            OffMusic();
        }
        else
        {
            OnMusic();
        }
    }

    public void OffMusic()
    {
        _musicOn.SetActive(false);
        _musicOff.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetString("audio", "off");
    }

    public void OnMusic()
    {
        _musicOff.SetActive(false);
        _musicOn.SetActive(true);
        AudioListener.volume = 1;
        PlayerPrefs.SetString("audio", "on");
    }

    public void PlayClickSound()
    {
        _audioSource.PlayOneShot(_clickSound);
    }

    public void PlauBuySound()
    {
        _audioSource.PlayOneShot(_buySound);
    }
}
