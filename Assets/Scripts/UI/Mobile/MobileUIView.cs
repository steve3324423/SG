using UnityEngine;

namespace SightMaster.Scripts.UI.Mobile
{
    public class MobileUIView : MonoBehaviour
    {
        private void Awake()
        {
            if (Application.isMobilePlatform == false)
                Destroy(gameObject);
        }
    }
}
