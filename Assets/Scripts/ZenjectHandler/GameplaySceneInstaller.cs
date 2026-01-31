using SightMaster.Scripts.Player;
using SightMaster.Scripts.Setting;
using UnityEngine;
using YG;
using Zenject;

namespace SightMaster.Scripts.ZenjectHandler
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private CameraRotationMobile _cameraRotation;
        [SerializeField] private InputHandler _inputHandler;
        [SerializeField] private PlayerCameraController _playerCameraController;
        [SerializeField] private PlayerYawRotator _playerYawRotate;
        [SerializeField] private Sensitivity _sensitivity;

        public override void InstallBindings()
        {
            if (Application.isMobilePlatform)
                Container.Bind<IInput>().To<InputMobile>().AsSingle();
            else
                Container.Bind<IInput>().To<DesktopInput>().AsSingle();

            Container.Bind<PlayerCameraController>().FromInstance(_playerCameraController).AsSingle();
            Container.Bind<CameraRotationMobile>().FromInstance(_cameraRotation).AsSingle();
            Container.Bind<PlayerYawRotator>().FromInstance(_playerYawRotate).AsSingle();
            Container.Bind<Sensitivity>().FromInstance(_sensitivity).AsSingle();
            Container.Bind<InputHandler>().FromInstance(_inputHandler).AsSingle();
            Container.Bind<Mover>().FromComponentOnRoot().AsSingle();
        }
    }
}
