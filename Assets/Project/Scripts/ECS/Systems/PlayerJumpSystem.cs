using Leopotam.EcsLite;
using Project.Scripts.ECS.Components;
using UnityEngine;

namespace Project.Scripts.ECS.Systems
{
    public class PlayerJumpSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems ecsSystems)
        {
            var playerGroundedFilter = ecsSystems.GetWorld().Filter<PlayerComponent>().Inc<PlayerInputComponent>().Inc<GroundedComponent>().End();
            var tryJumpFilter = ecsSystems.GetWorld().Filter<TryJump>().End();
            var playerPool = ecsSystems.GetWorld().GetPool<PlayerComponent>();

            foreach (var tryJumpEntity in tryJumpFilter)
            {
                ecsSystems.GetWorld().DelEntity(tryJumpEntity);
                foreach (var playerEntity in playerGroundedFilter)
                {
                    ref var playerComponent = ref playerPool.Get(playerEntity);

                    playerComponent.playerRB.AddForce(Vector3.up * playerComponent.PlayerJumpForce, ForceMode.VelocityChange);
                }
            }
        }
    }
}