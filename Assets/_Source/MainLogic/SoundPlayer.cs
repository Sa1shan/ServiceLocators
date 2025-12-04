using UnityEngine;
using _Source.interfaces;

namespace _Source.MainLogic
{
    public class SoundPlayer : ISoundPlayer
    {
        private readonly AudioSource _audioSource;
        public AudioClip OpenClip;
        public AudioClip CloseClip;

        public SoundPlayer(AudioSource audioSource, AudioClip openClip = null, AudioClip closeClip = null)
        {
            _audioSource = audioSource;
            OpenClip = openClip;
            CloseClip = closeClip;
        }

        public void PlayStartSound()
        {
            if (_audioSource == null || OpenClip == null)
            {
                return;
            }

            _audioSource.PlayOneShot(OpenClip);
        }

        public void PlayEndSound()
        {
            if (_audioSource == null || CloseClip == null)
            {
                return;
            }

            _audioSource.PlayOneShot(CloseClip);
        }
    }
}