using UnityEngine;

namespace Project.Scripts.ECS
{
    [CreateAssetMenu]
    public class GameConfig : ScriptableObject
    {
        public float PlayerSpeed;
        public float CameraFollowSmoothness;
    }
}