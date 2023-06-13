using UnityEngine;

namespace Script.Gallery
{
    public static class Boot
    {
        public static void Bootstrap(UiFactory uiFactory, ImageWebFactory imageWebFactory, Camera camera)
        {
            var mainMenu = uiFactory.CreateMainMenu();
            var gallery = uiFactory.CreateGallery();
            var image = uiFactory.CreateImageView();
            var loading = uiFactory.CreateLoading();

            var ui = new Ui(mainMenu, gallery, image, loading);
            
            var app = new App(ui, imageWebFactory, camera);
            
            app.GoToMainMenu();
        }
    }
}