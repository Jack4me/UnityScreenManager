using CodeBase.ScreenManager;
using UnityEngine;

namespace CodeBase.SceneManager {
    public class GameSceneUILoad : MonoBehaviour {
        public void ReloadScene() {
            ScreenManager.ScreenManager.Load(ScreenManager.ScreenManager.ScreenType.Preferences);
        }
    }
}