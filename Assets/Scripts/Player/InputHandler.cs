using SightMaster.Scripts.CameraHandlers;
using SightMaster.Scripts.HandlerPause;
using SightMaster.Scripts.LevelHandler;
using UnityEngine;

namespace SightMaster.Scripts.Player
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private Mover _mover;
        [SerializeField] private PlayerYawRotator _playerRotator;
        [SerializeField] private CameraFollowBullet _cameraFollow;
        [SerializeField] private PlayerCameraController _cameraController;
        [SerializeField] private PauseHandler _pauseHandler;
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private LevelEnder _levelEnder;

        public void EnableInput(bool enable)
        {
            if (_mover != null)
                _mover.EnableMovement(enable);

            if (_playerRotator != null)
                _playerRotator.EnableRotation(enable);

            if (_cameraController != null)
                _cameraController.EnableCamera(enable);
        }

        private void OnEnable()
        {
            _cameraFollow.Followed += OnFollowed;
            _pauseHandler.Paused += OnPaused;
            _playerHealth.Dead += OnDead;
            _levelEnder.Wined += OnWined;
        }

        private void OnDisable()
        {
            _cameraFollow.Followed -= OnFollowed;
            _pauseHandler.Paused -= OnPaused;
            _playerHealth.Dead -= OnDead;
            _levelEnder.Wined -= OnWined;
        }

        private void OnPaused(bool isPaused)
        {
            SetPlayerControlEnabled(!isPaused); 
        }

        private void OnDead()
        {
            SetPlayerControlEnabled(false);
        }

        private void OnWined()
        {
            SetPlayerControlEnabled(false);
        }

        private void OnFollowed(bool isFollowed)
        {
            SetPlayerControlEnabled(!isFollowed);
        }

        private void SetPlayerControlEnabled(bool isEnabled)
        {
            _cameraController.EnableCamera(isEnabled);
            _playerRotator.EnableRotation(isEnabled);
            _mover.EnableMovement(isEnabled);
        }
    }
}