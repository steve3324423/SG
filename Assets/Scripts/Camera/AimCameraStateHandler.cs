using SightMaster.Scripts.FSM;
using UnityEngine;

namespace SightMaster.Scripts.CameraHandlers
{
    public class AimCameraStateHandler : MonoBehaviour
    {
        private const string FollowEnable = "FollowEnable";
        private const string FollowDisable = "FollowDisable";

        [SerializeField] private Transform _mainCameraTransform;
        [SerializeField] private Transform _aimCameraTransform;
        [SerializeField] private CameraShakeHandler _cameraShake;
        [SerializeField] private CameraFollowBullet _followBullet;

        private AimCameraState _aimCameraEnableFollower;
        private AimCameraState _aimCameraDisableFollower;
        private StateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = new StateMachine();
            _aimCameraEnableFollower = new AimCameraState(_stateMachine, _mainCameraTransform, _aimCameraTransform,true);
            _aimCameraDisableFollower = new AimCameraState(_stateMachine, _mainCameraTransform, _aimCameraTransform,false);

            _stateMachine.AddState(FollowEnable, _aimCameraEnableFollower);
            _stateMachine.AddState(FollowDisable, _aimCameraDisableFollower);

            _stateMachine.SetState(FollowEnable);
        }

        private void OnEnable()
        {
            _followBullet.Followed += OnFollowed;
            _cameraShake.Shaking += OnShaking;
        }

        private void OnDisable()
        {
            _followBullet.Followed -= OnFollowed;
            _cameraShake.Shaking -= OnShaking;
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        private void OnFollowed(bool isFollowed)
        {
            if (isFollowed)
                SetState(FollowDisable);
            else
                SetState(FollowEnable);
        }

        private void OnShaking(bool isShaking)
        {
            if (isShaking)
                SetState(FollowDisable);
            else
                SetState(FollowEnable);
        }

        private void SetState(string nameState)
        {
            _stateMachine.SetState(nameState);
        }
    }
}