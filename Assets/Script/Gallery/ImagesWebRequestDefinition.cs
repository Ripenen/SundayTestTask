using UnityEngine;

namespace Script.Gallery
{
    [CreateAssetMenu(menuName = "Create ImagesWebRequestDefinition", fileName = "ImagesWebRequestDefinition", order = 0)]
    public class ImagesWebRequestDefinition : ScriptableObject
    {
        public string BaseUrl;
        public string Format;
        public int Count;
    }
}