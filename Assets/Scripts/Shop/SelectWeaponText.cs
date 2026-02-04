using System.Linq;
using TMPro;
using UnityEngine;
using YG;
using YG.LanguageLegacy;

namespace SightMaster.Scripts.Shop
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class SelectWeaponText : MonoBehaviour
    {
        [SerializeField] private BuyButton _buyButton;
        [SerializeField] private WeaponView _weaponView;
        [SerializeField] private LanguageYG _selectLanguageText;
        [SerializeField] private LanguageYG _selectedLanguageText;
        [SerializeField] private int _index = 1;

        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            _weaponView.WeaponChanged += OnWeaponChanged;
            _buyButton.Buyed += OnBuyed;
        }

        private void OnDisable()
        {
            _weaponView.WeaponChanged -= OnWeaponChanged;
            _buyButton.Buyed -= OnBuyed;
        }

        private void OnWeaponChanged(WeaponToBuy weapon)
        {
            _text.enabled = YG2.saves.idWeaponBuy.Any(id => id == _index);
            SetLanguageText(weapon.Id == _index);
        }

        private void OnBuyed(WeaponToBuy weapon)
        {
            if (weapon.Id == _index)
                OnWeaponChanged(weapon);
        }

        private void SetLanguageText(bool isSelected)
        {
            _selectedLanguageText.enabled = isSelected;
            _selectLanguageText.enabled = !isSelected;
        }
    }
}