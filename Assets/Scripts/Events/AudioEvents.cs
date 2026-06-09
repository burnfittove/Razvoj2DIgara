using System;
using UnityEngine;

namespace Events
{
    public class AudioEvents
    {
        public event Action<AudioClip> OnPlaySound;
        public event Action<AudioClip> OnPlaySoundWithRandomPitch;
        public event Func<AudioClip> OnGetItemSound;
        public event Action OnPlayShopMusic;
        public event Action OnPlayBattleMusic;
        public event Action OnStopMusic;

        public virtual void PlaySound(AudioClip obj)
        {
            OnPlaySound?.Invoke(obj);
        }

        public virtual AudioClip GetItemSound()
        {
            return OnGetItemSound?.Invoke();
        }

        public virtual void PlaySoundWithRandomPitch(AudioClip obj)
        {
            OnPlaySoundWithRandomPitch?.Invoke(obj);
        }

        public virtual void PlayShopMusic()
        {
            OnPlayShopMusic?.Invoke();
        }

        public virtual void PlayBattleMusic()
        {
            OnPlayBattleMusic?.Invoke();
        }


        public virtual void StopMusic()
        {
            OnStopMusic?.Invoke();
        }
    }
}