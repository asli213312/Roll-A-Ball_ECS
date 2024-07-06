using Leopotam.EcsLite;
using Project.Scripts.ECS.Components;
using UnityEngine;

namespace Project.Scripts.ECS.Systems
{
    public class HammersRunSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var filter = systems.GetWorld().Filter<HammerComponent>().End();
            var hammerPool = systems.GetWorld().GetPool<HammerComponent>();

            foreach (var entity in filter)
            {
                ref var hammerComponent = ref hammerPool.Get(entity);

                float speedRotation = 5f;
                hammerComponent.ObstacleTransform.Rotate(new Vector3(90, 0, 0) * speedRotation * Time.deltaTime);
                
            }
        }
    }
}