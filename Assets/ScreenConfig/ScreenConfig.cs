using UnityEngine;

namespace ScreenConfig {
    [CreateAssetMenu(fileName = "ScreenConfig", menuName = "ScreenManager/ScreenConfig", order = 1)]
    public class ScreenConfig : ScriptableObject {
        public string SceneName;
        public GameObject[] screens;
    }
}