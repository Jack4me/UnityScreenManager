using UnityEngine;

namespace CodeBase.SceneManager {
    public class GameSceneUILoad : MonoBehaviour {
        public void ReloadScene() {
            Loader.Load(Loader.Scene.Preferences);
        }
    }
}