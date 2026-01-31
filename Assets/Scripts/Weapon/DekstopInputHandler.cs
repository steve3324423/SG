using System;
using UnityEngine;

public class DekstopInputHandler : MonoBehaviour
{
    private bool _isEnabled = true;

    public event Action<bool> Shooting;
    public event Action<bool> Aiming;

    private void Update()
    {
        if (_isEnabled == false)
            return;

        bool currentShootState = Input.GetMouseButton(0);
        bool currentAimState = Input.GetMouseButton(1);
      
        Shooting?.Invoke(currentShootState);
        Aiming?.Invoke(currentAimState);
    }

    public void EnableDekstopHandler(bool enable)
    {
        _isEnabled = enable;

        if(_isEnabled == false)
        {

            Shooting?.Invoke(false);
            Aiming?.Invoke(false);
        }
    }
}