using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Script.Gallery
{
    public class ImageWebFactory
    {
        private readonly ImagesWebRequestDefinition _definition;

        private readonly List<int> _loadingImageIds = new();

        public int ImagesCounts => _definition.Count;
        
        public ImageWebFactory(ImagesWebRequestDefinition definition)
        {
            _definition = definition;
        }

        public IEnumerator LoadFromWeb(GalleryImage image)
        {
            if(_loadingImageIds.Contains(image.ID))
                yield break;
            
            var imageUrl = _definition.BaseUrl + image.ID + _definition.Format;
            
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageUrl);
            
            _loadingImageIds.Add(image.ID);

            yield return request.SendWebRequest();
            
            Texture2D texture = DownloadHandlerTexture.GetContent(request);
            
            var textureRect = new Rect(0, 0, texture.width, texture.height);
            
            image.SetSprite(Sprite.Create(texture, textureRect, new Vector2(0.5f, 0.5f)));

            _loadingImageIds.Remove(image.ID);
        }
    }
}