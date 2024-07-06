using Leopotam.EcsLite;
using Project.Scripts.ECS.Components;
using Project.Scripts.ECS.Services;
using UnityEngine;

namespace Project.Scripts.ECS.Systems
{
    public class DangerousInitSystem : IEcsInitSystem
    {
        public void Init(IEcsSystems ecsSystems)
        {
            var ecsWorld = ecsSystems.GetWorld();
            var dangerousPool = ecsWorld.GetPool<DangerousComponent>();
            
            foreach (var i in GameObject.FindGameObjectsWithTag(Constants.Tags.Dangerous))
            {
                var dangerousEntity = ecsWorld.NewEntity();

                dangerousPool.Add(dangerousEntity);
                ref var dangerousComponent = ref dangerousPool.Get(dangerousEntity);

                dangerousComponent.Transform = i.transform;
                dangerousComponent.PointA = i.transform.Find("A").position;
                dangerousComponent.PointB = i.transform.Find("B").position;
            }
        }
    }
}