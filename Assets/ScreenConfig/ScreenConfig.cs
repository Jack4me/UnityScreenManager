using UnityEngine;

namespace ScreenConfig {
    [CreateAssetMenu(fileName = "ScreenConfig", menuName = "ScreenManager/ScreenConfig", order = 1)]
    public class ScreenConfig : ScriptableObject {
        public string sceneName;
        public GameObject[] screens;
    }
}