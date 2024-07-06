using Leopotam.EcsLite;
using Project.Scripts.ECS.Components;
using Project.Scripts.ECS.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.ECS.Systems
{
    public class LevelInitSystem : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var gameData = systems.GetShared<GameData>();

            var levelEntity = world.NewEntity();

            var levelPool = systems.GetWorld().GetPool<LevelComponent>();
            levelPool.Add(levelEntity);

            //var levelGO = GameObject.FindGameObjectWithTag(Constants.Tags.Level);
            
            ref var levelComponent = ref levelPool.Get(levelEntity);

            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                levelComponent.Config = gameData.GameConfig.Levels[0];
                levelComponent.CurrentLevelIndex = 0;
                gameData.GameConfig.CurrentLevelIndex = 0;
            }
            else
            {
                Debug.Log("current index level: " + gameData.GameConfig.CurrentLevelIndex);
            }
        }
    }
}