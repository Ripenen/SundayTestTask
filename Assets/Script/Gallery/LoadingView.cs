using System.Collections;
using Script.Infrastructure;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Gallery
{
    public class LoadingView : UiView
    {
        [SerializeField] private TextMeshProUGUI _loading;
        [SerializeField] private Slider _slider;

        public IEnumerator LoadToGallery(App app, float loadingTime)
        {
            var value = 0f;

            while (value < loadingTime)
            {
                yield return new WaitForEndOfFrame();

                value += Time.deltaTime;

                var normalizedValue = value / loadingTime;
                
                _slider.value = normalizedValue;
                _loading.text = Mathf.RoundToInt(normalizedValue * 100) + "%";
            }
            
            app.GoToGallery();
        }
    }
}