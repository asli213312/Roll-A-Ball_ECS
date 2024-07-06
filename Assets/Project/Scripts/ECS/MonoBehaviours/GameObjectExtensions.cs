using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace _Kittens__Kitchen.Editor.Scripts.Utility.Extensions
{
    public static class GameObjectExtensions
    {
        public static async void ActivateThenDelay(this GameObject gameObject, Action afterDelay, float delay = 0f)
        {
            gameObject.SetActive(true);
            await Task.Delay((int)(delay * 1000));
            
            afterDelay?.Invoke();
        }
        
        public static async void Activate(this GameObject gameObject, float delay = 0f)
        {
            await Task.Delay((int)(delay * 1000));
            gameObject.SetActive(true);
        }

        public static async void Deactivate(this GameObject gameObject, float delay = 0f)
        {
            await Task.Delay((int)(delay * 1000));
            gameObject.SetActive(false);
        }

        public static void Destroy(this GameObject gameObject, float delay = 0f)
        {
            Object.Destroy(gameObject, delay);
        }
    }
}