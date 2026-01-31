using SightMaster.Scripts.UI;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SightMaster.Scripts.HandlerPause
{
    public class PauseHandler : MonoBehaviour
    {
        [SerializeField] private SettingPanelHandler _settingPauseHandler;

        private List<IPauseBlocker> _pauseBlockers = new List<IPauseBlocker>();
        private bool _isSettingActive;

        public event Action<bool> Paused;

        private void Awake()
        {
            FindAllPauseBlockers();
        }

        private void OnEnable()
        {
            SetTimeScale(1);
            SceneManager.sceneLoaded += OnSceneLoaded;
            _settingPauseHandler.Toggled += OnToggled;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            _settingPauseHandler.Toggled -= OnToggled;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            SetTimeScale(1);
        }

        private void Update()
        {
            if (_isSettingActive == false && Input.GetKeyDown(KeyCode.Escape) && IsPauseBlocked() == false)
                Pause();
        }

        private void OnToggled(bool isActivated)
        {
            _isSettingActive = isActivated;
            SetTimeScale(Time.timeScale == 0 ? 1 : 0);
        }

        private void SetTimeScale(float time)
        {
            Time.timeScale = time;
        }

        private bool IsPauseBlocked()
        {
            _pauseBlockers.RemoveAll(b => (b as MonoBehaviour) == null);

            foreach (var blocker in _pauseBlockers)
            {
                if (blocker.IsPauseBlocked)
                    return true;
            }
            return false;
        }

        private void FindAllPauseBlockers()
        {
            _pauseBlockers.Clear();
            MonoBehaviour[] allMonoBehaviours = FindObjectsOfType<MonoBehaviour>();

            foreach (var mb in allMonoBehaviours)
            {
                if (mb is IPauseBlocker blocker)
                    _pauseBlockers.Add(blocker);
            }
        }

        public void Pause()
        {
            SetTimeScale(Time.timeScale == 0 ? 1 : 0);
            Paused?.Invoke(Time.timeScale == 0);
        }
    }
}
