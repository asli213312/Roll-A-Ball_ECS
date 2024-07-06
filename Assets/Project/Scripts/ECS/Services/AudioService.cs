using System;
using UnityEngine;

namespace Project.Scripts.ECS.Services
{
    public class AudioService
    {
        public void PlaySound(AudioClip clip, AudioSource source, float volume = 0.5f)
        {
            source.PlayOneShot(clip);
            source.volume = volume;
        }

        public void Play(AudioClip clip, AudioSource source, Action afterPlay = null)
        {
            source.clip = clip;
            source.Play();
            
            if (afterPlay != null) source.Stop();
        }
    }
}