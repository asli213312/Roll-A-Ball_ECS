using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Project.Scripts.ECS
{
    public class Helper : MonoBehaviour
    {
        public IEnumerator ActivateThenDelay(GameObject go, float delay)
        {
            go.SetActive(true);
            yield return new WaitForSeconds(delay);
        }
    }
}