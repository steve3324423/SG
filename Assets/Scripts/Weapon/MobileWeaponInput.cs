using SightMaster.Scripts.UI;
using SightMaster.Scripts.UI.Mobile;
using System;

namespace SightMaster.Scripts.Weapon
{
    public class MobileWeaponInput : IInputWeapon
    {
        private AimButton _aimButtom;
        private ShootButton _shootButton;

        public MobileWeaponInput(AimButton aimButtom, ShootButton shootButton)
        {
            _aimButtom = aimButtom;
            _shootButton = shootButton;

            _shootButton.Shooting += OnShooting;
            _aimButtom.Aimed += OnAimed;
        }

        public event Action<bool> Shooting;
        public event Action<bool> Aiming;

        private void OnAimed(bool isAiming)
        {
            Aiming?.Invoke(isAiming);
        }

        private void OnShooting(bool isShooting)
        {
            Shooting?.Invoke(isShooting);
        }
    }
}
