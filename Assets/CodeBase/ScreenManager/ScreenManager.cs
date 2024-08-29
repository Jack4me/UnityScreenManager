using System;

namespace CodeBase.ScreenManager {
    public static class ScreenManager {
        public enum Screen {
            Loading,
            MainMenu,
            Preferences,
            ChooseLevel,
            Shop,
            FirstLevel,
            SecondLevel,

        }
        
        private static Screen _previousScreen; 
        private static Action onLoaderCallBack;
        public static void Load(Screen screen, bool useLoadingScreen = true) {
            _previousScreen = (Screen)Enum.Parse(typeof(Screen), UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            onLoaderCallBack = () => { UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(screen.ToString()); };

            if (useLoadingScreen) {
                UnityEngine.SceneManagement.SceneManager.LoadScene(Screen.Loading.ToString());
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
            Load(_previousScreen, useLoadingScreen);
        }
    }
}