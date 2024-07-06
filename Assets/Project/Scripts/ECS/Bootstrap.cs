using Leopotam.EcsLite;
using Leopotam.EcsLite.ExtendedSystems;
using LeopotamGroup.Globals;
using Project.Scripts.ECS.Components;
using Project.Scripts.ECS.Services;
using Project.Scripts.ECS.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.ECS
{
    sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private Helper helper;
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameConfig gameConfig;
        [SerializeField] private Text coinCounter;
        [SerializeField] private Slider healthSlider;
        
        private EcsWorld _world;
        private IEcsSystems initSystems;
        private IEcsSystems updateSystems;
        private IEcsSystems fixedUpdateSystems;
        private IEcsSystems lateUpdateSystems;

        private void Start()
        {
            _world = new EcsWorld();
            var gameData = new GameData()
            {
                AudioSource = audioSource,
                Helper = helper,
                PlayerWonPanel = winPanel,
                GameConfig = gameConfig,
                CoinCounter = coinCounter,
                HealthSlider = healthSlider,
                SceneService = Service<SceneService>.Get(true),
                AudioService = Service<AudioService>.Get(true)
            };

            healthSlider.maxValue = gameConfig.PlayerMaxHealth;
            healthSlider.value = gameConfig.PlayerMaxHealth;

            initSystems = new EcsSystems(_world, gameData)
                .Add(new LevelInitSystem())
                .Add(new PlayerInitSystem())
                .Add(new CoinInitSystem())
                .Add(new DangerousInitSystem());

            initSystems.Init();

            updateSystems = new EcsSystems(_world, gameData)
                .Add(new PlayerInputSystem())
                .Add(new CoinHitSystem())
                .Add(new DangerousRunSystem())
                .Add(new DangerousHitSystem())
                .Add(new WinSystem())
                .DelHere<HitComponent>();

            updateSystems.Init();

            fixedUpdateSystems = new EcsSystems(_world, gameData)
                .Add(new PlayerMoveSystem())
                .Add(new PlayerJumpSystem())
                .Add(new CoinRunSystem());

            fixedUpdateSystems.Init();

            lateUpdateSystems = new EcsSystems(_world, gameData)
                .Add(new CameraFollowSystem());

            lateUpdateSystems.Init();
        }

        private void Update()
        {
            updateSystems.Run();
        }

        private void FixedUpdate()
        {
            fixedUpdateSystems.Run();
        }

        private void LateUpdate()
        {
            lateUpdateSystems.Run();
        }

        private void OnDestroy()
        {
            initSystems.Destroy();
            updateSystems.Destroy();
            fixedUpdateSystems.Destroy();
            _world.Destroy();
        }
    }
}