using Leopotam.EcsLite;
using Project.Scripts.ECS.Components;
using UnityEngine;

namespace Project.Scripts.ECS.Systems
{
    public class CoinRunSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems ecsSystems)
        {
            var filter = ecsSystems.GetWorld().Filter<CoinComponent>().End();
            var coinsPool = ecsSystems.GetWorld().GetPool<CoinComponent>();

            foreach (var entity in filter)
            {
                ref var coinsComponent = ref coinsPool.Get(entity);
                Vector3 pos1 = coinsComponent.PointA;
                Vector3 pos2 = coinsComponent.PointB;

                coinsComponent.Transform.localPosition = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time, 1.0f));
                
                float rotationSpeed = 10f;
                
                coinsComponent.Transform.RotateAround(coinsComponent.Transform.position, Vector3.left, 360f);
            }
        }
    }
}
