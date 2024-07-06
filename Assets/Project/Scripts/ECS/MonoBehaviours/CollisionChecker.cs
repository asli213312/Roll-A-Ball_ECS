using Leopotam.EcsLite;
using Project.Scripts.ECS.Components;
using Project.Scripts.ECS.Services;
using UnityEngine;

namespace Project.Scripts.ECS.MonoBehaviours
{
    public class CollisionChecker : MonoBehaviour
    {
        public EcsWorld ecsWorld { get; set; }

        private void OnCollisionEnter(Collision collision)
        {
            var hit = ecsWorld.NewEntity();

            var hitPool = ecsWorld.GetPool<HitComponent>();
            hitPool.Add(hit);
            ref var hitComponent = ref hitPool.Get(hit);

            hitComponent.First = transform.root.gameObject;
            hitComponent.Other = collision.gameObject;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Constants.Tags.Coins))
            {
                other.gameObject.SetActive(false); 
            }
            var hit = ecsWorld.NewEntity();

            var hitPool = ecsWorld.GetPool<HitComponent>();
            hitPool.Add(hit);
            ref var hitComponent = ref hitPool.Get(hit);

            hitComponent.First = transform.root.gameObject;
            hitComponent.Other = other.gameObject;
        }
    }
}