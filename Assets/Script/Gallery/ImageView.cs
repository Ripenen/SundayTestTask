using Script.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Gallery
{
    public class ImageView : UiView
    {
        [SerializeField] private Image _image;
        [SerializeField] private Button _back;

        public void Setup(App app, GalleryImage image)
        {
            _back.onClick.RemoveAllListeners();
            _back.onClick.AddListener(app.GoToGallery);

            _image.preserveAspect = true;
            image.Apply(_image);
        }
    }
}