using Script.Infrastructure;
using UnityEngine;

namespace Script.ModelPreview
{
    public class ModelPreviewScreenBehaviour : ScreenBehavior
    {
        private readonly Model _model;
        private readonly Camera _camera;
        private Vector2 _previousViewport;

        public ModelPreviewScreenBehaviour(Model model, Camera camera)
        {
            _model = model;
            _camera = camera;
        }

        public override void Enter()
        {
            _camera.orthographic = false;
            
            _camera.transform.position = _model.transform.position;
            _camera.transform.position -= new Vector3(0, 0, 3);
            _camera.transform.LookAt(_model.transform);
        }

        public override void Update()
        {
            if (Input.GetMouseButton(0))
            {
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");

                _model.transform.Rotate(new Vector3(0, -mouseX * Sensitivity, 0), Space.World);
                _model.transform.Rotate(new Vector3(mouseY * Sensitivity, 0, 0), Space.World);
            }
        }

        private float Sensitivity => 5;
    }
}