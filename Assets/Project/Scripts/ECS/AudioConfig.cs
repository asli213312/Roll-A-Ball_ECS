using UnityEngine;

namespace Project.Scripts.ECS
{
    [CreateAssetMenu]
    public class AudioConfig : ScriptableObject
    {
        public AudioClip CoinCollected;
        public AudioClip DangerousHit;
    }
}