using CodeBase.SceneManager;
using UnityEngine;

namespace CodeBase.ScreenManager {
    

    public class SceneLoader : MonoBehaviour
    {
        

        public void LoadFirstLevel() {
            SceneHandler.Load(SceneHandler.SceneType.FirstLevel);
        } 
        public void LoadSecondLevel() {
            SceneHandler.Load(SceneHandler.SceneType.SecondLevel);
        } 
        public void LoadPreferences() {
            SceneHandler.Load(SceneHandler.SceneType.Preferences, false);
        }
        
        public void LoadMenu() {
            SceneHandler.Load(SceneHandler.SceneType.MainMenu, false);
        } 
        public void LoadChooseLevelMenu() {
            SceneHandler.Load(SceneHandler.SceneType.ChooseLevel, false);
        } 
        public void LoadShopMenu() {
            SceneHandler.Load(SceneHandler.SceneType.Shop, false);
        } 
    }
}