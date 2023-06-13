using UnityEngine;

namespace Script.Gallery
{
    [CreateAssetMenu(menuName = "Create Assets", fileName = "Assets", order = 0)]
    public class GalleryAssets : ScriptableObject
    {
        public UiPrefabs Prefabs;
        public ImagesWebRequestDefinition ImagesWebRequestDefinition;
    }
}