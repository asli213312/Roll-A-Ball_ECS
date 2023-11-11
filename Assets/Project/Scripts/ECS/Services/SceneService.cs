using UnityEngine.SceneManagement;

namespace Project.Scripts.ECS.Services
{
    public class SceneService
    {
        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}