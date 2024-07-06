using UnityEngine;

namespace Project.Scripts.ECS.Components
{
    public struct LevelComponent
    {
        public Transform Transform;
        public LevelConfig Config;
        public int CurrentLevelIndex;
    }
}