using CodeBase.SceneManager;
using UnityEngine;

namespace CodeBase.ScreenManager {
    

    public class SceneLoader : MonoBehaviour
    {
        

        public void LoadFirstLevel() {
            SceneManager.Load(SceneManager.SceneType.FirstLevel);
        } 
        public void LoadSecondLevel() {
            SceneManager.Load(SceneManager.SceneType.SecondLevel);
        } 
        public void LoadPreferences() {
            SceneManager.Load(SceneManager.SceneType.Preferences, false);
        }
        
        public void LoadMenu() {
            SceneManager.Load(SceneManager.SceneType.MainMenu, false);
        } 
        public void LoadChooseLevelMenu() {
            SceneManager.Load(SceneManager.SceneType.ChooseLevel, false);
        } 
        public void LoadShopMenu() {
            SceneManager.Load(SceneManager.SceneType.Shop, false);
        } 
    }
}