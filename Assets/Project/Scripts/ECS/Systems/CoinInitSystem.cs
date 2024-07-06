using Leopotam.EcsLite;
using Project.Scripts.ECS.Components;
using Project.Scripts.ECS.Services;
using UnityEngine;

namespace Project.Scripts.ECS.Systems
{
    public class CoinInitSystem : IEcsInitSystem
    {
        public void Init(IEcsSystems ecsSystems)
        {
            var ecsWorld = ecsSystems.GetWorld();
            var coinsPool = ecsWorld.GetPool<CoinComponent>();
            
            foreach (var i in GameObject.FindGameObjectsWithTag(Constants.Tags.Coins))
            {
                var coinsEntity = ecsWorld.NewEntity();

                coinsPool.Add(coinsEntity);
                ref var coinsComponent = ref coinsPool.Get(coinsEntity);

                coinsComponent.Transform = i.transform;
                coinsComponent.PointA = i.transform.Find("A").position;
                coinsComponent.PointB = i.transform.Find("B").position;
            }
        }
    }
}