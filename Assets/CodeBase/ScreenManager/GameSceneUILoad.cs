using CodeBase.ScreenManager;
using UnityEngine;

namespace CodeBase.SceneManager {
    public class GameSceneUILoad : MonoBehaviour {
        public void ReloadScene() {
            ScreenManager.SceneHandler.Load(ScreenManager.SceneHandler.SceneType.Preferences);
        }
    }
}