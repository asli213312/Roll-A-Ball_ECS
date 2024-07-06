using Leopotam.EcsLite;
using Project.Scripts.ECS.Components;
using UnityEngine;

namespace Project.Scripts.ECS.MonoBehaviours
{
    public class GroundChecker : MonoBehaviour
    {
        public EcsPool<GroundedComponent> groundedPool;
        public int playerEntity;

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                if (!groundedPool.Has(playerEntity))
                {
                    groundedPool.Add(playerEntity);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                if (groundedPool.Has(playerEntity))
                {
                    groundedPool.Del(playerEntity);
                }
            }
        }
    }
}