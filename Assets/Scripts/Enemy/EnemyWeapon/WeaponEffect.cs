using UnityEngine;

namespace SightMaster.Scripts.Enemy.WeaponEnemy
{
    [RequireComponent(typeof(ParticleSystem))]
    public class WeaponEffect : MonoBehaviour
    {
        [SerializeField] private EnemyWeapon _weapon;
        [SerializeField] private Transform _positionSource;
        [SerializeField] private bool _usePositionSource = false;

        private ParticleSystem _particleSystem;

        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }

        private void OnEnable()
        {
            _weapon.Shooted += OnShooted;
        }

        private void OnDisable()
        {
            _weapon.Shooted -= OnShooted;
        }

        private void OnShooted()
        {
            if (_usePositionSource && _positionSource != null)
                transform.position = _positionSource.position;

            _particleSystem.Play();
        }
    }
}