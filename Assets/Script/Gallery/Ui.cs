using Script.Infrastructure;

namespace Script.Gallery
{
    public class Ui
    {
        private readonly MainMenuView _mainMenu;
        private readonly GalleryView _gallery;
        private readonly ImageView _image;
        private readonly LoadingView _loading;

        public Ui(MainMenuView mainMenu, GalleryView gallery, ImageView image, LoadingView loading)
        {
            _mainMenu = mainMenu;
            _gallery = gallery;
            _image = image;
            _loading = loading;
        }

        public void ShowMainMenu(App app)
        {
            HideAll();

            _mainMenu.Enable();
            
            _mainMenu.OnClickGallery(app);
        }
        
        public void ShowLoading(App app)
        {
            HideAll();

            _loading.Enable();
            
            MonoCached.StartCustomCoroutine(_loading.LoadToGallery(app, 2));
        }

        public GalleryView ShowGallery()
        {
            HideAll();

            _gallery.Enable();

            return _gallery;
        }

        private void HideAll()
        {
            _mainMenu.Disable();
            _gallery.Disable();
            _image.Disable();
            _loading.Disable();
        }

        public void ShowImageView(App app, GalleryImage image)
        {
            HideAll();
            
            _image.Enable();
            _image.Setup(app, image);
        }
    }
}