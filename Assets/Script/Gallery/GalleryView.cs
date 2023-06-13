using System.Collections.Generic;
using Script.Infrastructure;
using UnityEngine;

namespace Script.Gallery
{
    public class GalleryView : UiView
    {
        [SerializeField] private Transform _content;
        [SerializeField] private List<GalleryImage> _images;
        
        public RectTransform Viewport => transform as RectTransform;

        public IEnumerable<GalleryImage> Images => _images;

        public void CreateDummyImages(int imagesCounts, IGalleryImageHandler handler)
        {
            _images = new List<GalleryImage>(imagesCounts);
            
            for (int i = 0; i < imagesCounts; i++)
            {
                var image = new GameObject { transform = { parent = _content } };

                var galleryImage = image.AddComponent<GalleryImage>();
                
                galleryImage.Setup(null, handler, i + 1);
                
                _images.Add(galleryImage);
            }
        }
    }
}