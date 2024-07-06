using Project.Scripts.ECS.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.ECS
{
    public class GameData
    {
        public AudioSource AudioSource;
        public Helper Helper;
        public GameConfig GameConfig;
        public AudioService AudioService;
        public SceneService SceneService;
        public Text CoinCounter;
        public GameObject PlayerWonPanel;
        public Slider HealthSlider;
    }
}