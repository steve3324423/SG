using SightMaster.Scripts.DamageObject;
using UnityEngine;

namespace SightMaster.Scripts.Enemy.HealthHandler
{
    public class EnemyHealth : HealthSystem
    {
        [SerializeField] private float _timeForDead = 1.7f;

        private HeadEnemy _head;

        protected override void Awake()
        {
            base.Awake();
            _head = GetComponentInChildren<HeadEnemy>();
        }

        private void OnEnable()
        {
            if (_head != null)
                _head.Hited += OnHited;
        }

        private void OnDisable()
        {
            if (_head != null)
                _head.Hited -= OnHited;
        }

        protected override void Die()
        {
            base.Die();
            Destroy(gameObject, _timeForDead);
        }

        private void OnHited(int damage)
        {
            TakeDamage(damage);
        }
    }
}