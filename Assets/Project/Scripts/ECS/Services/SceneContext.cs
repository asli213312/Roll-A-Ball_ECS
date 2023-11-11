using Game;
using UnityEngine;

namespace Project.Scripts.ECS.Services
{
    public class SceneContext : MonoBehaviour, ISceneContext
    {
        [SerializeField] private Camera camera;

        public Camera Camera => camera;
    }
}