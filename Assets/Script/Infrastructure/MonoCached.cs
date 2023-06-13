using System.Collections;
using UnityEngine;

namespace Script.Infrastructure
{
    public class MonoCached : MonoBehaviour
    {
        private static MonoCached _instance;
        
        public static ScreenBehavior ScreenBehavior;

        private void Awake()
        {
            _instance = this;
        }

        private void Update()
        {
            ScreenBehavior?.Update();
        }

        public static void StartCustomCoroutine(IEnumerator routine)
        {
            _instance.StartCoroutine(routine);
        }
    }
}
