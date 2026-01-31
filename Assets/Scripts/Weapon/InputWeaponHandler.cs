using SightMaster.Scripts.DamageObject;
using SightMaster.Scripts.HandlerPause;
using SightMaster.Scripts.LevelHandler;
using UnityEngine;

namespace SightMaster.Scripts.Weapon
{
    public class InputWeaponHandler : MonoBehaviour
    {
        [SerializeField] private DekstopInputHandler _dekstopHandler;
        [SerializeField] private PauseHandler _pauseHandler;
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private LevelEnder _levelEnder;

        private void OnEnable()
        {
            _pauseHandler.Paused += OnPaused;
            _playerHealth.Dead += OnDead;
            _levelEnder.Wined += OnWined;
        }

        private void OnDisable()
        {
            _pauseHandler.Paused -= OnPaused;
            _playerHealth.Dead -= OnDead;
            _levelEnder.Wined -= OnWined;
        }

        private void OnPaused(bool isPaused)
        {
            SetWeaponControlEnabled(!isPaused);
        }

        private void OnDead()
        {
            SetWeaponControlEnabled(false);
        }

        private void OnWined()
        {
            SetWeaponControlEnabled(false);
        }

        private void SetWeaponControlEnabled(bool isEnabled)
        {
            _dekstopHandler.EnableDekstopHandler(isEnabled);
        }
    }
}
