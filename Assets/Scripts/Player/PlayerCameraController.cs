using UnityEngine;
using Zenject;

namespace SightMaster.Scripts.Player
{
    public class PlayerCameraController : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private float _thirdPersonDistance = 3f;
        [SerializeField] private float _cameraCollisionRadius = 0.2f;
        [SerializeField] private LayerMask _cameraCollisionMask;
        [SerializeField] private Vector3 _firstPersonOffset = new Vector3(0f, 1.7f, 0f);

        private bool _isEnabled = true;
        private IInput _input;

        [Inject]
        public void Construct(IInput input)
        {
            _input = input;
        }

        private void LateUpdate()
        {
            if (_isEnabled == false || _player == null || _cameraTransform == null || _input == null)
                return;

            Quaternion cameraRotation = _input.GetCameraRotation();
            UpdateThirdPerson(cameraRotation);
        }

        private void UpdateThirdPerson(Quaternion cameraRotation)
        {
            _cameraTransform.rotation = cameraRotation;

            Vector3 pivot = _player.position + _player.TransformVector(_firstPersonOffset);
            Vector3 desiredCameraPos = pivot - _cameraTransform.forward * _thirdPersonDistance;
            RaycastHit hit;

            if (Physics.SphereCast(
                pivot,
                _cameraCollisionRadius,
                (desiredCameraPos - pivot).normalized,
                out hit,
                _thirdPersonDistance,
                _cameraCollisionMask,
                QueryTriggerInteraction.Ignore))
            {
                float distance = hit.distance;
                desiredCameraPos = pivot + (desiredCameraPos - pivot).normalized * (distance - 0.05f);
            }

            _cameraTransform.position = desiredCameraPos;
        }

        public void EnableCamera(bool enable)
        {
            _isEnabled = enable;
        }
    }
}