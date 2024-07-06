using UnityEngine;

namespace Project.Scripts.ECS
{
    [CreateAssetMenu]
    public class LevelConfig : ScriptableObject
    {
        public int LevelIndex;
        public int CoinsToComplete;
    }
}