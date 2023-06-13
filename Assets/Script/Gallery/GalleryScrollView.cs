using UnityEngine;
using UnityEngine.UI;

namespace Script.Gallery
{
    public class GalleryScrollView : MonoBehaviour
    {
        [SerializeField] private GridLayoutGroup _content;

        public GridLayoutGroup Content => _content;
    }
}