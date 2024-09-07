using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.ScreenManager {
    using UnityEngine.SceneManagement;

    public class ScreenManager : MonoBehaviour {
        [SerializeField] private GameObject HUDInstance;
        public static ScreenManager instance;
        public Stack<GameObject> screenHistory = new Stack<GameObject>();

        public GameObject mainMenuScreen;
        public GameObject settingsScreen;
        public GameObject pauseMenuScreen;
        public GameObject shopScreen;

        void Awake() {
            mainMenuScreen.SetActive(true);
            screenHistory.Push(mainMenuScreen);

            if (instance != null) {
                Destroy(gameObject);
            }
            else {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }

            GameObject hudPrefab = Resources.Load<GameObject>("UI/HUD/HUD");
            HUDInstance = Instantiate(hudPrefab);
            DontDestroyOnLoad(HUDInstance);
            //InitializeHUD(HUDInstance);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnDestroy() {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
            InitializeHUD();
        }

        // Метод для инициализации экранов в HUD
        public void InitializeHUD() {
            settingsScreen = HUDInstance.transform.Find("SettingsScreen").gameObject;


            Debug.Log("HUD экраны инициализированы для новой сцены: " + SceneManager.GetActiveScene().name);
        }


      

        public void ShowScreen(string panelName) {
            HideAllPanels();

            GameObject screen = null; // Для хранения текущего экрана

            switch (panelName) {
                case "MainMenu":
                    screen = mainMenuScreen;
                    break;
                case "Settings":
                    screen = settingsScreen;
                    break;
                case "PauseMenu":
                    screen = pauseMenuScreen;
                    break;
                case "Shop":
                    screen = shopScreen;
                    break;
                default:
                    Debug.LogError("Unknown panel: " + panelName);
                    return;
            }


            if (screenHistory.Count > 0) {
                // here is a error
                screenHistory.Peek().SetActive(false);
                Debug.LogError("screenHistory.Count 0");
            }


            screen.SetActive(true);
            screenHistory.Push(screen);
        }

        private void HideAllPanels() {
            if (mainMenuScreen != null) mainMenuScreen.SetActive(false);
            if (settingsScreen != null) settingsScreen.SetActive(false);
            if (pauseMenuScreen != null) pauseMenuScreen.SetActive(false);
            if (shopScreen != null) shopScreen.SetActive(false);
        }

        public void GoBack() {
            if (screenHistory.Count > 1) {
                Debug.LogError("screenHistory.Count 01");
                screenHistory.Pop().SetActive(false);
                screenHistory.Peek().SetActive(true);
            }
        }
    }
}