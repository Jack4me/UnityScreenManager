using CodeBase.SceneManager;
using UnityEngine;

namespace CodeBase.ScreenManager {
    public class LoadScreens : MonoBehaviour {
        public void LoadFirstLevel() {
            ScreenManager.Load(ScreenManager.Screen.FirstLevel);
        } 
        public void LoadSecondLevel() {
            ScreenManager.Load(ScreenManager.Screen.SecondLevel);
        } 
        public void LoadPreferences() {
            ScreenManager.Load(ScreenManager.Screen.Preferences, false);
        }
        
        public void LoadMenu() {
            ScreenManager.Load(ScreenManager.Screen.MainMenu, false);
        } 
        public void LoadChooseLevelMenu() {
            ScreenManager.Load(ScreenManager.Screen.ChooseLevel, false);
        } 
        public void LoadShopMenu() {
            ScreenManager.Load(ScreenManager.Screen.Shop, false);
        } 
    }
}