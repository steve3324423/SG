using UnityEngine;

namespace SightMaster.Scripts.Audios
{
    public class CrossSceneObject : MonoBehaviour
    {
        private static CrossSceneObject _instance;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(this);
        }
    }
}
