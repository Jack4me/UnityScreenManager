using System;

namespace CodeBase.ScreenManager {
    public static class ScreenManager {
        public enum ScreenType { 
            Loading,
            MainMenu,
            Preferences,
            ChooseLevel,
            Shop,
            FirstLevel,
            SecondLevel,

        }
        
        private static ScreenType _previousScreenType; 
        private static Action onLoaderCallBack;
        public static void Load(ScreenType screenType, bool useLoadingScreen = true) {
            _previousScreenType = (ScreenType)Enum.Parse(typeof(ScreenType), UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            onLoaderCallBack = () => { UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(screenType.ToString()); };

            if (useLoadingScreen) {
                UnityEngine.SceneManagement.SceneManager.LoadScene(ScreenType.Loading.ToString());
            } else {
                
                LoaderCallBack();
            }
        }

        public static void LoaderCallBack() {
            if (onLoaderCallBack != null) {
                onLoaderCallBack();
                onLoaderCallBack = null;
            }
        }
        public static void LoadPreviousScene(bool useLoadingScreen = true) {
            Load(_previousScreenType, useLoadingScreen);
        }
    }
}