using UnityEngine;

namespace Project.Scripts.ECS.Components
{
    public struct PlayerComponent
    {
        public Transform playerTransform;
        public Rigidbody playerRB;
        public SphereCollider playerCollider;
        public Vector3 playerVelocity;
        public float PlayerSpeed;
        public float PlayerJumpForce;
        public float Health;
        public int Coins;
    }
}