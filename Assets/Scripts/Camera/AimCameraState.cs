using SightMaster.Scripts.FSM;
using UnityEngine;

namespace SightMaster.Scripts.CameraHandlers
{
    public class AimCameraState : FSMState
    {
        private bool _isCanRotate = true;
        private Transform _cameraTransform;
        private Transform _aimCamera;

        public AimCameraState(StateMachine stateMachine, Transform cameraTransform, Transform aimCamera,bool isCanRotate)
            : base(stateMachine)
        {
            _cameraTransform = cameraTransform;
            _isCanRotate = isCanRotate;
            _aimCamera = aimCamera;
        }

        public override void Update()
        {
            if (_isCanRotate)
                _aimCamera.rotation = _cameraTransform.rotation;
        }
    }
}