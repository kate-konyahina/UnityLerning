using System;
using UnityEngine;
using Zenject;

namespace TopDownZenject
{
    public class InputHandler : ITickable
    {
        private Camera _camera;

        public Action<Vector3> OnClicked;

        public InputHandler([Inject(Id = BaseIds.GameCameraId)] Camera camera)
        {
            _camera = camera;
        }

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);
                var layer = LayerMask.GetMask(BaseIds.layerName);
                if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, layer))
                {
                    OnClicked?.Invoke(hitInfo.point);
                }
            }
        }
    }
}
