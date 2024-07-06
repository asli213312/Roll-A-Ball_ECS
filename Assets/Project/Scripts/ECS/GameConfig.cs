using UnityEngine;

namespace Project.Scripts.ECS
{
    [CreateAssetMenu]
    public class GameConfig : ScriptableObject
    {
        [Header("Player Options")] 
        public float PlayerMaxHealth;
        public float PlayerSpeed;
        public float PlayerJumpHeight;

        [Header("Dangerous Options")] 
        public float DangerousDamageOnHit;
        
        [Header("Camera Options")]
        public float CameraFollowSmoothness;

        [Header("Other Options")] 
        public AudioConfig AudioConfig;

        [Space(5)]
        public LevelConfig[] Levels;

        public int CurrentLevelIndex { get; set; }

        public void IncreaseLevel()
        {
            CurrentLevelIndex++;
        }
    }
}