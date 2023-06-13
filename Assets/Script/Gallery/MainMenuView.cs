using Script.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Gallery
{
    public class MainMenuView : UiView
    {
        [SerializeField] private Button _gallery;
        
        public void OnClickGallery(App app)
        {
            _gallery.onClick.RemoveAllListeners();
            
            _gallery.onClick.AddListener(app.GoToLoadingGallery);
        }
    }
}