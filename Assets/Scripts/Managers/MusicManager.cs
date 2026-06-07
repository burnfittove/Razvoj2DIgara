using System;
using Events;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    private AudioSource _audioSource;

    [Header("Battle")]
    public AudioResource introBattleMusic;
    public AudioResource loopBattleMusic;
    [Header("Shop")]
    public AudioResource introShopMusic;
    public AudioResource loopShopMusic;
    
    private bool isIntroFinished = false;

    private void Awake()
    {
        TryGetComponent(out _audioSource);
    }

    private void Start()
    {
        GameEventManager.Instance.audioEvents.OnPlayBattleMusic += PlayBattleMusic;
        GameEventManager.Instance.audioEvents.OnPlayShopMusic += PlayShopMusic;
    }

    private void PlayBattleMusic()
    {
        Debug.Log("Play Battle Music");
        if (_audioSource.resource == introBattleMusic || _audioSource.resource == loopBattleMusic) return;
        Debug.Log("Played Battle Music");
        
        _audioSource.resource = introBattleMusic;
        _audioSource.Play();
        _audioSource.loop = false;
        isIntroFinished = false;
    }

    private void PlayShopMusic()
    {
        if (_audioSource.resource == introShopMusic || _audioSource.resource == loopShopMusic) return;
        
        _audioSource.resource = introShopMusic;
        _audioSource.Play();
        _audioSource.loop = false;
        isIntroFinished = false;
    }

    private void Update()
    {
        if (_audioSource.isPlaying) return;
        if (isIntroFinished) return;

        // Continue battle music
        if (_audioSource.resource == introBattleMusic)
        {
            PlayLoop(loopBattleMusic);
            return;
        }
        
        // Otherwise, continue shop music
        PlayLoop(loopShopMusic);
    }

    private void PlayLoop(AudioResource audioResource)
    {
        _audioSource.resource = audioResource;
        _audioSource.Play();
        _audioSource.loop = true;
        isIntroFinished = true;
    }
}
