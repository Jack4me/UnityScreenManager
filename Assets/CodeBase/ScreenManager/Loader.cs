namespace CodeBase.SceneManager {
using System;
using UnityEngine.SceneManagement;
    public static class Loader {
        public enum Scene {
            Loading,
            MainMenu,
            Preferences,
            ChooseLevel,
            Shop,
            FirstLevel,
            SecondLevel,

        }
        
        private static Scene previousScene; 
        private static Action onLoaderCallBack;
        public static void Load(Scene scene, bool useLoadingScreen = true) {
            previousScene = (Scene)Enum.Parse(typeof(Scene), SceneManager.GetActiveScene().name);
            onLoaderCallBack = () => { SceneManager.LoadSceneAsync(scene.ToString()); };

            if (useLoadingScreen) {
                SceneManager.LoadScene(Scene.Loading.ToString());
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
            Load(previousScene, useLoadingScreen);
        }
    }
}