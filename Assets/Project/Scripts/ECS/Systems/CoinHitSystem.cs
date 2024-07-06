using Leopotam.EcsLite;
using Project.Scripts.ECS.Components;
using Project.Scripts.ECS.Services;

namespace Project.Scripts.ECS.Systems
{
    public class CoinHitSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems ecsSystems)
        {
            var gameData = ecsSystems.GetShared<GameData>();
            var hitFilter = ecsSystems.GetWorld().Filter<HitComponent>().End();
            var hitPool = ecsSystems.GetWorld().GetPool<HitComponent>();
            var playerFilter = ecsSystems.GetWorld().Filter<PlayerComponent>().End();
            var playerPool = ecsSystems.GetWorld().GetPool<PlayerComponent>();

            foreach (var hitEntity in hitFilter)
            {
                ref var hitComponent = ref hitPool.Get(hitEntity);

                foreach (var playerEntity in playerFilter)
                {
                    ref var playerComponent = ref playerPool.Get(playerEntity);

                    if (hitComponent.Other.CompareTag(Constants.Tags.Coins))
                    {
                        playerComponent.Coins += 1;
                        gameData.AudioService.PlaySound(gameData.GameConfig.AudioConfig.CoinCollected, gameData.AudioSource);
                        gameData.CoinCounter.text = "Coins: " + playerComponent.Coins;
                    }
                }

            }
        }
    }
}