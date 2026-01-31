using System;
using UnityEngine;

namespace SightMaster.Scripts.Player
{
    public abstract class InputControl : IInput
    {
        private float _xRotation;
        private float _yRotation;
        private float _zRotation = 0f;

        public event Action<float, float> RotationValuesChanged;

        public abstract float Pitch { get; }
        public abstract float Yaw { get; }

        public virtual Vector3 GetDirection(Transform transformPlayer)
        {
            return Vector3.zero;
        }

        public abstract Quaternion GetCameraRotation();

        public abstract void SetYaw(float yaw);

        protected Quaternion SetCameraRotation(float xValue, float yValue)
        {
            _xRotation = xValue;
            _yRotation = yValue;

            RotationValuesChanged?.Invoke(xValue, yValue);
            return Quaternion.Euler(_xRotation, _yRotation, _zRotation);
        }
    }
}