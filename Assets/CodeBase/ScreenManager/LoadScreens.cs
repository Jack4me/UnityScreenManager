using CodeBase.SceneManager;
using UnityEngine;

namespace CodeBase.ScreenManager {
    public class LoadScreens : MonoBehaviour {
        public void LoadFirstLevel() {
            ScreenManager.Load(ScreenManager.ScreenType.FirstLevel);
        } 
        public void LoadSecondLevel() {
            ScreenManager.Load(ScreenManager.ScreenType.SecondLevel);
        } 
        public void LoadPreferences() {
            ScreenManager.Load(ScreenManager.ScreenType.Preferences, false);
        }
        
        public void LoadMenu() {
            ScreenManager.Load(ScreenManager.ScreenType.MainMenu, false);
        } 
        public void LoadChooseLevelMenu() {
            ScreenManager.Load(ScreenManager.ScreenType.ChooseLevel, false);
        } 
        public void LoadShopMenu() {
            ScreenManager.Load(ScreenManager.ScreenType.Shop, false);
        } 
    }
}