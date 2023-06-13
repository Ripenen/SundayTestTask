using System.Threading.Tasks;
using Script.Infrastructure;
using UnityEngine;

namespace Script.Gallery
{
    public class App
    {
        private readonly Ui _ui;
        private readonly ImageWebFactory _webFactory;
        private readonly Camera _camera;

        private GalleryScreenBehavior _behavior;

        public App(Ui ui, ImageWebFactory webFactory, Camera camera)
        {
            _ui = ui;
            _webFactory = webFactory;
            _camera = camera;
        }

        public void GoToMainMenu()
        {
            Screen.orientation = ScreenOrientation.Portrait;
            _ui.ShowMainMenu(this);
        }
        
        public void GoToLoadingGallery()
        {
            _ui.ShowLoading(this);
        }
        
        public async void GoToGallery()
        {
            Screen.orientation = ScreenOrientation.Portrait;
            
            var gallery = _ui.ShowGallery();

            if (_behavior is null)
            {
                _behavior = new GalleryScreenBehavior(_webFactory, gallery, _camera, this);

                await Task.Delay(100);
            
                _behavior.Enter();   
            }

            MonoCached.ScreenBehavior = _behavior;
        }
        
        public void GoToImageView(GalleryImage image)
        {
            Screen.orientation = ScreenOrientation.AutoRotation;
            _ui.ShowImageView(this, image);
            
            MonoCached.ScreenBehavior = null;
        }
    }
}