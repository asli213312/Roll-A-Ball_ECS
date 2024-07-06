using Leopotam.EcsLite;
using Project.Scripts.ECS.Components;
using Project.Scripts.ECS.Services;
using UnityEngine;

namespace Project.Scripts.ECS.Systems
{
    public class DangerousHitSystem : IEcsRunSystem
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

                    if (hitComponent.Other.CompareTag(Constants.Tags.Dangerous))
                    {
                        float currentHealth = playerComponent.Health -= gameData.GameConfig.DangerousDamageOnHit;
                        gameData.HealthSlider.value = currentHealth;
                        gameData.AudioService.PlaySound(gameData.GameConfig.AudioConfig.DangerousHit, gameData.AudioSource);

                        if (playerComponent.Health <= 0)
                        {
                            playerComponent.playerTransform.gameObject.SetActive(false);
                            ecsSystems.GetWorld().DelEntity(playerEntity);
                            gameData.SceneService.ReloadScene();
                        }
                    }
                }
            }
        }
    }
}