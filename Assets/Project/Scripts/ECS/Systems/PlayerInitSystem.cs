using Leopotam.EcsLite;
using Project.Scripts.ECS.Components;
using Project.Scripts.ECS.MonoBehaviours;
using UnityEngine;

namespace Project.Scripts.ECS.Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        public void Init(IEcsSystems ecsSystems)
        {
            var ecsWorld = ecsSystems.GetWorld();
            var gameData = ecsSystems.GetShared<GameData>();

            var playerEntity = ecsWorld.NewEntity();

            var playerPool = ecsWorld.GetPool<PlayerComponent>();
            playerPool.Add(playerEntity);
            ref var playerComponent = ref playerPool.Get(playerEntity);
            var playerInputPool = ecsWorld.GetPool<PlayerInputComponent>();
            playerInputPool.Add(playerEntity);

            var playerGO = GameObject.FindGameObjectWithTag("Player");
            playerGO.GetComponentInChildren<GroundChecker>().groundedPool = ecsSystems.GetWorld().GetPool<GroundedComponent>();
            playerGO.GetComponentInChildren<GroundChecker>().playerEntity = playerEntity;
            playerGO.GetComponentInChildren<CollisionChecker>().ecsWorld = ecsWorld;
            playerComponent.PlayerSpeed = gameData.GameConfig.PlayerSpeed;
            playerComponent.playerTransform = playerGO.transform;
            playerComponent.Health = gameData.GameConfig.PlayerMaxHealth;
            playerComponent.PlayerJumpForce = gameData.GameConfig.PlayerJumpHeight;
            playerComponent.playerCollider = playerGO.GetComponent<SphereCollider>();
            playerComponent.playerRB = playerGO.GetComponent<Rigidbody>();
        }
    }
}