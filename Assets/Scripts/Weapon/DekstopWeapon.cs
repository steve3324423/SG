using System;

namespace SightMaster.Scripts.Weapon
{
    public class DekstopWeapon : IInputWeapon
    {
        private DekstopInputHandler _dekstopHandler;

        public DekstopWeapon(DekstopInputHandler dekstopHandler)
        {
            _dekstopHandler = dekstopHandler;

            _dekstopHandler.Shooting += OnShooting;
            _dekstopHandler.Aiming += OnAiming;
        }

        public event Action<bool> Shooting;
        public event Action<bool> Aiming;

        private void OnShooting(bool isShooting)
        {
            Shooting?.Invoke(isShooting);
        }

        private void OnAiming(bool isAiming)
        {
            Aiming?.Invoke(isAiming);
        }
    }
}