using UnityEngine;
using UnityEngine.Audio;

public class MenuMusic : MonoBehaviour
{
    private AudioSource _audioSource;

    public AudioResource introMenuMusic;
    public AudioResource loopMenuMusic;

    private bool isIntroFinished;
    
    private void Awake()
    {
        TryGetComponent(out _audioSource);
    }

    private void Update()
    {
        if (_audioSource.isPlaying) return;
        if (isIntroFinished) return;

        _audioSource.resource = loopMenuMusic;
        _audioSource.loop = true;
        _audioSource.Play();
        isIntroFinished = true;
    }
}
