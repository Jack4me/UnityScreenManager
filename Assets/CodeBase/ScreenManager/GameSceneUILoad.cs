using CodeBase.ScreenManager;
using UnityEngine;

namespace CodeBase.SceneManager {
    public class GameSceneUILoad : MonoBehaviour {
        public void ReloadScene() {
            ScreenManager.SceneManager.Load(ScreenManager.SceneManager.SceneType.Preferences);
        }
    }
}