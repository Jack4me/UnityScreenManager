using UnityEngine;

namespace CodeBase.SceneManager {
    public class LoadScenes : MonoBehaviour {
        public void LoadFirstLevel() {
            Loader.Load(Loader.Scene.FirstLevel);
        } 
        public void LoadSecondLevel() {
            Loader.Load(Loader.Scene.SecondLevel);
        } 
        public void LoadPreferences() {
            Loader.Load(Loader.Scene.Preferences, false);
        }
        
        public void LoadMenu() {
            Loader.Load(Loader.Scene.MainMenu, false);
        } 
        public void LoadChooseLevelMenu() {
            Loader.Load(Loader.Scene.ChooseLevel, false);
        } 
        public void LoadShopMenu() {
            Loader.Load(Loader.Scene.Shop, false);
        } 
    }
}