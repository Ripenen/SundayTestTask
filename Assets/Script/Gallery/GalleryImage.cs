using UnityEngine;
using UnityEngine.UI;

namespace Script.Gallery
{
    public class GalleryImage : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private int _id;

        private Sprite _loadingImage;
        private IGalleryImageHandler _handler;

        public bool Loaded => _image.sprite != _loadingImage;

        public int ID => _id;

        public RectTransform RectTransform => _rectTransform;

        public void Setup(Sprite loadingImage, IGalleryImageHandler handler, int id)
        {
            _image = gameObject.AddComponent<Image>();
            _button = gameObject.AddComponent<Button>();
            
            _rectTransform = transform as RectTransform;
            
            _loadingImage = loadingImage;
            _image.sprite = loadingImage;
            _handler = handler;
            _id = id;
            
            _button.onClick.AddListener(HandleClick);
        }

        private void HandleClick()
        {
            if (!Loaded)
                return;
            
            _handler.Handle(this);
        }

        public void SetSprite(Sprite sprite)
        {
            _image.sprite = sprite;
        }

        public void Apply(Image image)
        {
            image.sprite = _image.sprite;
        }
    }
}