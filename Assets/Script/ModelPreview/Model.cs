using UnityEngine;
using UnityEngine.EventSystems;

namespace Script.ModelPreview
{
    public class Model : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            _meshRenderer.material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 1);
        }
    }
}