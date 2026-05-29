using System;
using Events;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        private AudioSource _audioSource;
        [SerializeField] private AudioClip itemSound;

        private void Awake()
        {
            TryGetComponent(out _audioSource);
        }

        private void Start()
        {
             GameEventManager.Instance.audioEvents.OnPlaySound += PlaySound;
             GameEventManager.Instance.audioEvents.OnPlaySoundWithRandomPitch += PlaySoundWithRandomPitch;
             GameEventManager.Instance.audioEvents.OnGetItemSound += GetItemSound;
        }

        private void PlaySound(AudioClip obj)
        {
            _audioSource.PlayOneShot(obj);
        }

        private void PlaySoundWithRandomPitch(AudioClip obj)
        {
            _audioSource.pitch = Random.Range(0.9f, 1.1f);
            _audioSource.PlayOneShot(obj);
        }

        private AudioClip GetItemSound()
        {
            return itemSound;
        }
    }
}