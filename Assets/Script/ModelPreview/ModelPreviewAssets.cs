using UnityEngine;

namespace Script.ModelPreview
{
    [CreateAssetMenu(menuName = "Create ModelPreviewAssets", fileName = "ModelPreviewAssets", order = 0)]
    public class ModelPreviewAssets : ScriptableObject
    {
        public Model Object;
    }
}