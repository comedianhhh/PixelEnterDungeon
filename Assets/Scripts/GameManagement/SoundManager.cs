using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace benjohnson
{
    public class SoundManager : Singleton<SoundManager>
    {
        [SerializeField] AudioSource effectsSource;
        [SerializeField] AudioSource musicSource;

        [SerializeField] List<AudioProfile> clips;
        [SerializeField] List<AudioProfile> music;

        public void PlaySound(int i)
        {
            effectsSource.PlayOneShot(clips[i].Clip(), clips[i].volume);
        }

        public void PlayMusic(int i)
        {
            musicSource.PlayOneShot(clips[i].Clip(), clips[i].volume);
        }
    }

    [System.Serializable]
    public struct AudioProfile
    {
        public AudioClip[] clips;
        public AudioClip Clip()
        {
            return clips[Random.Range(0, clips.Length)];
        }
        [Range(0, 1)] public float volume;
    }
}
