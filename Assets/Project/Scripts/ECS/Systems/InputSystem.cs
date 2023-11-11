using Leopotam.EcsLite;

namespace Project.Scripts.ECS.Systems
{
    public class InputSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        
        public void Run(IEcsSystems systems)
        {
            var entity = _world.NewEntity();
        }
    }
}