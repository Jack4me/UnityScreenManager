using UnityEngine;

namespace CodeBase.ScreenManager {
    public class ScreenInitializer : MonoBehaviour
    {
       
            [SerializeField] private string screenName;

            void Start() {
                // Регистрация экрана в реестре ScreenManager
                ScreenManager.instance.RegisterScreen(screenName, gameObject);
                gameObject.SetActive(false);  
            }
        
    }
}
