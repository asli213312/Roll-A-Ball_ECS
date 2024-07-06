using Leopotam.EcsLite;
using Project.Scripts.ECS.Components;
using Project.Scripts.ECS.Services;
using UnityEngine;

namespace Project.Scripts.ECS.Systems
{
    public class HammersInitSystem : IEcsInitSystem
    {
        public void Init(IEcsSystems ecsSystems)
        {
            var ecsWorld = ecsSystems.GetWorld();
            var dangerousPool = ecsWorld.GetPool<HammerComponent>();
            
            foreach (var i in GameObject.FindGameObjectsWithTag(Constants.Tags.Hammers))
            {
                var dangerousEntity = ecsWorld.NewEntity();

                dangerousPool.Add(dangerousEntity);
                ref var dangerousComponent = ref dangerousPool.Get(dangerousEntity);

                dangerousComponent.ObstacleTransform = i.transform;
            }
        }
    }
}