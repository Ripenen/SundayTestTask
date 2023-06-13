using UnityEngine;

namespace Script.Infrastructure
{
    public class UiView : MonoBehaviour
    {
        public void Destroy() => Destroy(gameObject);
        public void Enable() => gameObject.SetActive(true);
        public void Disable() => gameObject.SetActive(false);
    }
}