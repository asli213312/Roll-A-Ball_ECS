using UnityEngine;

namespace Project.Scripts.ECS.Components
{
    public struct CameraComponent
    {
        public Transform cameraTransform;
        public Vector3 curDirection;
        public Vector3 offset;
        public float cameraSmoothness;
    }
}