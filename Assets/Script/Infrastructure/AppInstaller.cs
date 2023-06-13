using Script.Gallery;
using Script.ModelPreview;
using UnityEngine;

namespace Script.Infrastructure
{
    public class AppInstaller : MonoBehaviour, IInstaller<GalleryAssets>, IInstaller<ModelPreviewAssets>
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Camera _camera;
        
        public void Install(ModelPreviewAssets assets)
        {
            var model = Instantiate(assets.Object, Vector3.zero, Quaternion.identity);

            var behavior = new ModelPreviewScreenBehaviour(model, _camera);

            behavior.Enter();
            
            MonoCached.ScreenBehavior = behavior;
        }

        public void Install(GalleryAssets assets)
        {
            var uiFactory = new UiFactory(assets.Prefabs, _canvas);
            var imageWebFactory = new ImageWebFactory(assets.ImagesWebRequestDefinition);
            
            Boot.Bootstrap(uiFactory, imageWebFactory, _camera);
        }
    }
}