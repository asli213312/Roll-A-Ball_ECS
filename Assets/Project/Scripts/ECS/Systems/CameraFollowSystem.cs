using Leopotam.EcsLite;
using Project.Scripts.ECS.Components;
using UnityEngine;

namespace Project.Scripts.ECS.Systems
{
    public class CameraFollowSystem : IEcsInitSystem, IEcsRunSystem
    {
        private int _cameraEntity;

        public void Init(IEcsSystems ecsSystems)
        {
            var gameData = ecsSystems.GetShared<GameData>();

            var cameraEntity = ecsSystems.GetWorld().NewEntity();

            var cameraPool = ecsSystems.GetWorld().GetPool<CameraComponent>();
            cameraPool.Add(cameraEntity);
            ref var cameraComponent = ref cameraPool.Get(cameraEntity);

            cameraComponent.cameraTransform = Camera.main.transform;
            cameraComponent.cameraSmoothness = gameData.GameConfig.CameraFollowSmoothness;
            cameraComponent.curDirection = Vector3.zero;
            cameraComponent.offset = new Vector3(0f, 1f, -2f);

            _cameraEntity = cameraEntity;
        }

        public void Run(IEcsSystems ecsSystems)
        {
            var filter = ecsSystems.GetWorld().Filter<PlayerComponent>()
                .Inc<PlayerInputComponent>()
                .End();
            
            var playerPool = ecsSystems.GetWorld().GetPool<PlayerComponent>();
            var cameraPool = ecsSystems.GetWorld().GetPool<CameraComponent>();
            var playerInputPool = ecsSystems.GetWorld().GetPool<PlayerInputComponent>();

            ref var cameraComponent = ref cameraPool.Get(_cameraEntity);

            foreach(var entity in filter)
            {
                ref var playerComponent = ref playerPool.Get(entity);
                ref var playerInputComponent = ref playerInputPool.Get(entity);

                Vector3 currentPosition = cameraComponent.cameraTransform.position;
                Vector3 targetPoint = playerComponent.playerTransform.position + cameraComponent.offset;
                
                cameraComponent.cameraTransform.position = Vector3.SmoothDamp(currentPosition, targetPoint, ref cameraComponent.curDirection, cameraComponent.cameraSmoothness);

                cameraComponent.cameraTransform.LookAt(playerComponent.playerTransform.position);
            }   
        }
    }
}