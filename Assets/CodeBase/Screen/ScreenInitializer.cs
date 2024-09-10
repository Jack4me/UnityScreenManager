using UnityEngine;

namespace CodeBase.ScreenManager {
    public class ScreenInitializer : MonoBehaviour
    {
       
            [SerializeField] private string screenName;

            void Start() {
                // Регистрация экрана в реестре ScreenManager
                CodeBase.Screen.ScreenManager.instance.RegisterScreen(screenName, gameObject);
                if (gameObject.CompareTag("Menu") ) {
                    return;
                }
                gameObject.SetActive(false);
            }
        
    }
}
