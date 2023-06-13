using System.Collections.Generic;
using Script.Infrastructure;
using UnityEngine;

namespace Script.Gallery
{
    public class GalleryScreenBehavior : ScreenBehavior, IGalleryImageHandler
    {
        private readonly ImageWebFactory _imageWebFactory;
        private readonly GalleryView _galleryView;
        private readonly Camera _camera;
        private readonly App _app;

        public GalleryScreenBehavior(ImageWebFactory imageWebFactory, GalleryView galleryView, Camera camera, App app)
        {
            _imageWebFactory = imageWebFactory;
            _galleryView = galleryView;
            _camera = camera;
            _app = app;
        }

        public override void Enter()
        {
            _galleryView.CreateDummyImages(_imageWebFactory.ImagesCounts, this);
        }

        public override void Update()
        {
            foreach (var image in GetVisibleImages(_galleryView.Images))
            {
                MonoCached.StartCustomCoroutine(_imageWebFactory.LoadFromWeb(image));
            }
        }

        private IEnumerable<GalleryImage> GetVisibleImages(IEnumerable<GalleryImage> images)
        {
            foreach (var image in images)
            {
                if(image.Loaded)
                    continue;
                
                var visible = image.RectTransform.IsVisibleFrom(_camera);

                if (visible)
                    yield return image;
            }
        }

        public void Handle(GalleryImage image)
        {
            _app.GoToImageView(image);
        }
    }
}