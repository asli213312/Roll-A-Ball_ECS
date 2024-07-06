using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Project.Scripts.ECS.Components;
using Unity.VisualScripting;
using UnityEngine;

namespace Project.Scripts.ECS.Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems ecsSystems)
        {
            var filter = ecsSystems.GetWorld().Filter<PlayerInputComponent>()
                .End();
            
            var playerInputPool = ecsSystems.GetWorld().GetPool<PlayerInputComponent>();
            var tryJumpPool = ecsSystems.GetWorld().GetPool<TryJump>();
            var gameData = ecsSystems.GetShared<GameData>();

            foreach (var entity in filter)
            {
                ref var playerInputComponent = ref playerInputPool.Get(entity);

                playerInputComponent.MoveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
                
                if (Input.GetKeyDown(KeyCode.R))
                {
                    gameData.SceneService.ReloadScene();
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    var tryJump = ecsSystems.GetWorld().NewEntity();
                    tryJumpPool.Add(tryJump);
                }
            }
        }
    }
}