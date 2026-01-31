using UI_InputSystem.Base;
using UnityEngine;

namespace SightMaster.Scripts.Player
{
    public class InputMobile : InputControl
    {
        private CameraRotationMobile _cameraRotation;

        public InputMobile(CameraRotationMobile cameraRotation)
        {
            _cameraRotation = cameraRotation;
        }

        public override float Pitch => _cameraRotation.RotationX;
        public override float Yaw => _cameraRotation.RotationY;

        public override Vector3 GetDirection(Transform transformPlayer)
        {
            float horizontal = UIInputSystem.ME.GetAxisHorizontal(JoyStickAction.Movement);
            float vertical = UIInputSystem.ME.GetAxisVertical(JoyStickAction.Movement);

            return transformPlayer.right * horizontal + transformPlayer.forward * vertical;
        }

        public override Quaternion GetCameraRotation()
        {
            return SetCameraRotation(_cameraRotation.RotationX, _cameraRotation.RotationY);
        }

        public override void SetYaw(float yaw)
        {
            SetCameraRotation(_cameraRotation.RotationX, _cameraRotation.RotationY);
        }
    }
}