using System;
using Script.Infrastructure;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Script.Gallery
{
    public class UiFactory
    {
        private readonly UiPrefabs _prefabs;
        private readonly Canvas _canvas;

        public UiFactory(UiPrefabs prefabs, Canvas canvas)
        {
            _prefabs = prefabs;
            _canvas = canvas;
        }

        public MainMenuView CreateMainMenu() => CreateUi(_prefabs.MainMenu);
        public GalleryView CreateGallery() => CreateUi(_prefabs.Gallery);
        public ImageView CreateImageView() => CreateUi(_prefabs.ImageScreen);
        public LoadingView CreateLoading() => CreateUi(_prefabs.Loading);


        private T CreateUi<T>(T prefab, Action<T> onInstantiated = null) where T : UiView
        {
            var obj = Instantiate(prefab);
            
            obj.Disable();
        
            onInstantiated?.Invoke(obj);

            return obj;
        }

        private T Instantiate<T>(T prefab) where T : Object => Object.Instantiate(prefab, _canvas.transform);
    }
}