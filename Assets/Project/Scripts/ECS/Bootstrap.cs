using Leopotam.EcsLite;
using LeopotamGroup.Globals;
using Project.Scripts.ECS.Services;
using Project.Scripts.ECS.Systems;
using UnityEngine;

namespace Project.Scripts.ECS
{
    sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GameConfig gameConfig;
        
        private EcsWorld _world;
        private IEcsSystems initSystems;
        private IEcsSystems updateSystems;
        private IEcsSystems fixedUpdateSystems;
        private IEcsSystems lateUpdateSystems;

        private void Start()
        {
            _world = new EcsWorld();
            var gameData = new GameData()
            {
                GameConfig = gameConfig,
                SceneService = Service<SceneService>.Get(true)
            };

            initSystems = new EcsSystems(_world, gameData)
                .Add(new PlayerInitSystem());

            initSystems.Init();

            updateSystems = new EcsSystems(_world, gameData)
                .Add(new PlayerInputSystem());

            updateSystems.Init();

            fixedUpdateSystems = new EcsSystems(_world, gameData)
                .Add(new CameraFollowSystem());
            
            fixedUpdateSystems.Init();

            lateUpdateSystems = new EcsSystems(_world, gameData)
                .Add(new PlayerMoveSystem());

            lateUpdateSystems.Init();
        }

        private void Update()
        {
            updateSystems.Run();
        }

        private void FixedUpdate()
        {
            fixedUpdateSystems.Run();
        }

        private void LateUpdate()
        {
            lateUpdateSystems.Run();
        }

        private void OnDestroy()
        {
            initSystems.Destroy();
            updateSystems.Destroy();
            fixedUpdateSystems.Destroy();
            _world.Destroy();
        }
    }
}