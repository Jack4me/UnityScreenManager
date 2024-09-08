using UnityEngine;

namespace ScreenConfig {
    [CreateAssetMenu(fileName = "ScreenConfig", menuName = "ScreenManager/ScreenConfig", order = 1)]
    public class ScreenConfig : ScriptableObject {
        public GameObject[] screens;
    }
}