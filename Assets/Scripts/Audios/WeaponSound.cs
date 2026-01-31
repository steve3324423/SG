using SightMaster.Scripts.Weapon;
using UnityEngine;

namespace SightMaster.Scripts.Audios
{
    [RequireComponent(typeof(AudioSource))]
    public class WeaponSound : MonoBehaviour
    {
        [SerializeField] private PlayerWeapon[] _playerWeapons;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            foreach (PlayerWeapon ammo in _playerWeapons)
                ammo.Shooted += OnShooted;
        }

        private void OnDisable()
        {
            foreach (PlayerWeapon ammo in _playerWeapons)
                ammo.Shooted -= OnShooted;
        }

        private void SetClip()
        {
            foreach (PlayerWeapon ammo in _playerWeapons)
            {
                if (ammo.gameObject.activeSelf)
                    _audioSource.clip = ammo.GetComponent<AudioSource>().clip;
            }
        }

        private void OnShooted()
        {
            if (_audioSource.clip == null)
                SetClip();

            _audioSource.Play();
        }
    }
}
