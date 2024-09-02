using UnityEngine;

namespace CodeBase.ScreenManager {
    public class PersistentUI : MonoBehaviour
    {
        private static PersistentUI instance;

        void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}