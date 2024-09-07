using UnityEngine;

namespace CodeBase.ScreenManager {
    public class PersistentUI : MonoBehaviour
    {
        public static PersistentUI instanceUIManager;

        void Awake()
        {
            if (instanceUIManager != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instanceUIManager = this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}