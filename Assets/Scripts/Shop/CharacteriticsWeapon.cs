using UnityEngine;

namespace SightMaster.Scripts.Shop
{
    [RequireComponent(typeof(WeaponToBuy))]
    public class CharacteriticsWeapon : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private int _timeReload;
        [SerializeField] private int _magazine—apacity;

        private WeaponToBuy _weapon;

        public int Id { get; private set; }

        private void Awake()
        {
            _weapon = GetComponent<WeaponToBuy>();
            Id = _weapon.Id;
        }

        public int GetDamage()
        {
            return _damage;
        }

        public int GetTimeReload()
        {
            return _timeReload;
        }

        public int GetMagazineCapacity()
        {
            return _magazine—apacity;
        }
    }
}