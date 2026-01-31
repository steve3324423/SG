using System;
using System.Collections;
using SightMaster.Scripts.Weapon;
using UnityEngine;

namespace SightMaster.Scripts.CameraHandlers
{
    public class CameraShakeHandler : MonoBehaviour
    {
        [SerializeField] private PlayerWeapon[] _weaponAmmo;

        private float _speed = 30f;

        public event Action<bool> Shaking;

        private void OnEnable()
        {
            foreach (PlayerWeapon weapon in _weaponAmmo)
                weapon.Shooted += OnShooted;
        }

        private void OnDisable()
        {
            foreach (PlayerWeapon weapon in _weaponAmmo)
                weapon.Shooted -= OnShooted;
        }

        private void OnShooted()
        {
            StartCoroutine(Recoil());
        }

        private IEnumerator Recoil()
        {
            float time = .1f;
            Vector3 initialRotation = transform.localEulerAngles;
            Vector3 recoilDirection = GetRandomRecoilDirection();
            Shaking?.Invoke(true);

            while (time > 0)
            {
                yield return null;

                transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles + recoilDirection, initialRotation, _speed * Time.deltaTime);
                time -= Time.deltaTime;
            }

            Shaking?.Invoke(false);
        }

        private Vector3 GetRandomRecoilDirection()
        {
            float minValue = .5f;
            float maxValue = .9f;
            float xValue = UnityEngine.Random.Range(minValue, maxValue);

            return new Vector3(-xValue, 0, 0);
        }
    }
}