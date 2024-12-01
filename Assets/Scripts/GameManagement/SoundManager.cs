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

        private void Update()
        {
            if (!musicSource.isPlaying)
                PlayMusic(0);
        }

        public void PlaySound(string id)
        {
            for (int i = 0; i < clips.Count; i++)
            {
                if (clips[i].name == id)
                    PlaySound(i);
            }
        }

        public void PlaySound(int i)
        {
            effectsSource.PlayOneShot(clips[i].Clip(), clips[i].volume);
        }

        public void PlayMusic(int i)
        {
            musicSource.PlayOneShot(music[i].Clip(), music[i].volume);
        }
    }

    [System.Serializable]
    public class AudioProfile
    {
        public string name;
        public AudioClip[] clips;
        public AudioClip Clip()
        {
            return clips[Random.Range(0, clips.Length)];
        }
        [Range(0, 1)] public float volume = 0.5f;
    }
}
