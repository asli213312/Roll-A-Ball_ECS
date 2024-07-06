using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.ECS.Services
{
    public class SceneService
    {
        private AudioSource source;
        
        public void LoadNextScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            Debug.Log("sceneCountInBuildSettings: " + SceneManager.sceneCountInBuildSettings);
            
            if (currentSceneIndex <= SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            else
                Debug.LogError("Next scene not found");
        }
        
        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}