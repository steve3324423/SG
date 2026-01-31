using UnityEngine;
using Zenject;

namespace SightMaster.Scripts.Player
{
    public class PlayerYawRotator : MonoBehaviour
    {
        [SerializeField] private Transform _playerRoot;

        private IInput _input;
        private bool _isEnabled = true;

        [Inject]
        public void Construct(IInput input)
        {
            _input = input;
        }

        private void LateUpdate()
        {
            if (!_isEnabled || _playerRoot == null || _input == null)
                return;

            float yaw = _input.Yaw;
            Vector3 euler = _playerRoot.eulerAngles;
            euler.y = yaw;
            _playerRoot.rotation = Quaternion.Euler(euler);
        }

        public void EnableRotation(bool enable)
        {
            _isEnabled = enable;
        }
    }
}