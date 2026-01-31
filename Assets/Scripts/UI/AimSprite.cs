using SightMaster.Scripts.CameraHandlers;
using SightMaster.Scripts.Weapon;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SightMaster.Scripts.UI
{
    [RequireComponent(typeof(RawImage))]
    public class AimSprite : MonoBehaviour
    {
        [SerializeField] private CameraFollowBullet _cameraFollowBullet;
        [SerializeField] private PlayerWeapon[] _playerWeapons;
        [SerializeField] private Sprite[] _sprites;

        private IInputWeapon _inputWeapon;
        private bool _isFollowed;
        private Texture _texture;
        private RawImage _rawImage;

        [Inject]
        public void Construct(IInputWeapon inputWeapon)
        {
            _inputWeapon = inputWeapon;
            _inputWeapon.Aiming += OnAimed;
        }

        private void Awake()
        {
            _rawImage = GetComponent<RawImage>();
        }

        private void Start()
        {
            SetTexture();
        }

        private void OnEnable()
        {
            _cameraFollowBullet.Followed += OnFollowed;
        }

        private void OnDisable()
        {
            _cameraFollowBullet.Followed -= OnFollowed;
            _inputWeapon.Aiming += OnAimed;
        }

        private void SetTexture()
        {
            for (int i = 0; i < _playerWeapons.Length; i++)
            {
                if (_playerWeapons[i].gameObject.activeSelf)
                    _texture = _sprites[i].texture;
            }

            _rawImage.texture = _texture;
        }

        private void OnFollowed(bool isFollowed)
        {
            _rawImage.enabled = !isFollowed;
            _isFollowed = isFollowed;
        }

        private void OnAimed(bool isAimed)
        {
            if (_isFollowed == false)
                _rawImage.enabled = isAimed;
        }
    }
}