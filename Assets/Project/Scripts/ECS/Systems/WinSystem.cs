using System.Threading.Tasks;
using _Kittens__Kitchen.Editor.Scripts.Utility.Extensions;
using Leopotam.EcsLite;
using Project.Scripts.ECS.Components;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.ECS.Systems
{
    public class WinSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var filter = systems.GetWorld().Filter<PlayerComponent>()
                .End();
            
            var gameData = systems.GetShared<GameData>();

            var playerPool = systems.GetWorld().GetPool<PlayerComponent>();

            foreach (var entity in filter)
            {
                ref var playerComponent = ref playerPool.Get(entity);
                
                if (playerComponent.Coins >= gameData.GameConfig.Levels[gameData.GameConfig.CurrentLevelIndex].CoinsToComplete)
                {
                    if (gameData.GameConfig.CurrentLevelIndex <= gameData.GameConfig.Levels.Length)
                    {
                        gameData.GameConfig.IncreaseLevel();
                        gameData.PlayerWonPanel.ActivateThenDelay(gameData.SceneService.LoadNextScene, 3f);
                    }
                }
            }
        }
    }
}