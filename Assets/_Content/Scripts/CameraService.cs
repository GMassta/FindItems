using UnityEngine;
using VContainer.Unity;

namespace _Content.Scripts
{
    public class CameraService: IInitializable, ICameraService
    {
        private Camera _camera;
        private ILevelService _levelService;

        public Camera Camera => _camera;
        
        public CameraService(ILevelService levelService)
        {
            _camera = Camera.main;
            _levelService = levelService;
        }

        public void Initialize()
        {
            var background = _levelService.LevelBackground;
            if(!background) return;
            
            var bounds = background.bounds;
            var renderWidth = bounds.size.x;
            var renderHeight = bounds.size.y;
            var renderAspect = renderWidth / renderHeight;
            var aspect = (float)Screen.width / Screen.height;

            if (renderAspect > aspect)
                _camera.orthographicSize = (renderWidth / renderAspect) * .5f;
            else
                _camera.orthographicSize = renderHeight * .5f;
        }
    }
}