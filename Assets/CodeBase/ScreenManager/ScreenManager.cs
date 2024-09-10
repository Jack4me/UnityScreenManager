using System.Collections.Generic;

namespace CodeBase.ScreenManager {
    using UnityEngine.SceneManagement;
    // public class ScreenManager : MonoBehaviour
    // {
    //     [SerializeField] private GameObject HUDInstance;
    //     public static ScreenManager instance;
    //     public Stack<GameObject> screenHistory = new Stack<GameObject>();
    //
    //     public GameObject mainMenuScreen;
    //     public GameObject settingsScreen;
    //     public GameObject pauseMenuScreen;
    //     public GameObject shopScreen;
    //
    //     void Awake() {
    //
    //         mainMenuScreen.SetActive(true);
    //         screenHistory.Push(mainMenuScreen);
    //
    //         if (instance != null) {
    //             Destroy(gameObject);
    //         }
    //         else {
    //             instance = this;
    //             DontDestroyOnLoad(gameObject);
    //         }
    //
    //         if (HUDInstance == null) {
    //             GameObject hudPrefab = Resources.Load<GameObject>("UI/HUD/HUD");
    //             HUDInstance = Instantiate(hudPrefab);
    //             DontDestroyOnLoad(HUDInstance);
    //         } else {
    //             Debug.Log("HUD уже существует, новый экземпляр не создаётся.");
    //         }
    //         SceneManager.sceneLoaded += OnSceneLoaded;
    //     }
    //
    //     void OnDestroy() {
    //         SceneManager.sceneLoaded -= OnSceneLoaded;
    //     }
    //
    //     void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
    //         InitializeHUD();
    //     }
    //
    //     // Метод для инициализации экранов в HUD
    //     public void InitializeHUD() {
    //         
    //         settingsScreen = HUDInstance.transform.Find("SettingsScreen").gameObject;
    //
    //
    //         Debug.Log("HUD экраны инициализированы для новой сцены: " + SceneManager.GetActiveScene().name);
    //     }
    //
    //
    //   
    //
    //     public void ShowScreen(string panelName) {
    //         HideAllPanels();
    //
    //         GameObject screen = null; // Для хранения текущего экрана
    //
    //         switch (panelName) {
    //             case "MainMenu":
    //                 screen = mainMenuScreen;
    //                 break;
    //             case "Settings":
    //                 screen = settingsScreen;
    //                 break;
    //             case "PauseMenu":
    //                 screen = pauseMenuScreen;
    //                 break;
    //             case "Shop":
    //                 screen = shopScreen;
    //                 break;
    //             default:
    //                 Debug.LogError("Unknown panel: " + panelName);
    //                 return;
    //         }
    //
    //
    //         // if (screenHistory.Count > 0) {
    //         //     // here is a error
    //         //     screenHistory.Peek().SetActive(false);
    //         //     Debug.LogError("screenHistory.Count 0");
    //         // }
    //
    //         if (screenHistory.Count > 0) {
    //             GameObject previousScreen = screenHistory.Peek();
    //             if (previousScreen != null) {
    //                 previousScreen.SetActive(false);
    //             } else {
    //                 Debug.LogWarning("Предыдущий экран был уничтожен.");
    //             }
    //         }
    //         screen.SetActive(true);
    //         screenHistory.Push(screen);
    //     }
    //
    //     private void HideAllPanels() {
    //         if (mainMenuScreen != null) mainMenuScreen.SetActive(false);
    //         if (settingsScreen != null) settingsScreen.SetActive(false);
    //         if (pauseMenuScreen != null) pauseMenuScreen.SetActive(false);
    //         if (shopScreen != null) shopScreen.SetActive(false);
    //     }
    //
    //     public void GoBack() {
    //         if (screenHistory.Count > 1) {
    //             // Проверяем, существует ли объект
    //             GameObject currentScreen = screenHistory.Pop();
    //             if (currentScreen != null) {
    //                 currentScreen.SetActive(false);
    //             }
    //
    //             GameObject previousScreen = screenHistory.Peek();
    //             if (previousScreen != null) {
    //                 previousScreen.SetActive(true);
    //             } else {
    //                 Debug.LogWarning("Previous screen is missing or destroyed.");
    //             }
    //         }
    //     }
    // }
    using UnityEngine;
    using ScreenConfig;


    public class ScreenManager : MonoBehaviour {
        public static ScreenManager instance;
        public Stack<GameObject> screenHistory = new Stack<GameObject>();
        public Dictionary<string, GameObject> screenRegistry = new Dictionary<string, GameObject>();

        public GameObject[] screensTest;

        // Список конфигураций для каждой сцены
        [SerializeField] private ScreenConfig[] screenConfigs;

        private GameObject HUDInstance;

        void Awake() {
            if (instance != null) {
                Destroy(gameObject);
            }
            else {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }

            LoadHUD();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnDestroy() {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
            Debug.Log("name" + scene.name);
            LoadScreensForScene(scene.name);
        }

        private void LoadHUD() {
            if (HUDInstance == null) {
                GameObject hudPrefab = Resources.Load<GameObject>("UI/HUD/HUD");
                HUDInstance = Instantiate(hudPrefab);
                DontDestroyOnLoad(HUDInstance);
            }
        }

        private void LoadScreensForScene(string sceneName) {
            // Поиск конфигурации экранов для текущей сцены
            foreach (var config in screenConfigs) {
                if (config.SceneName == sceneName) {
                    InitializeScreens(config.screens);
                    Debug.Log(config.SceneName + "config.name");
                    return;
                }
            }

            Debug.LogError("Конфигурация экранов для сцены " + sceneName + " не найдена!");
        }

        private void InitializeScreens(GameObject[] screens) {
            screenHistory.Clear();

            // Инициализируем экраны для данной сцены
            foreach (GameObject screenPrefab in screens) {
                GameObject screen = Instantiate(screenPrefab, HUDInstance.transform);
                screen.SetActive(true); // Все экраны скрыты по умолчанию
            }

            // Активируем первый экран, например, главное меню
            if (screens.Length > 0) {
                screens[0].SetActive(true);
                screenHistory.Push(screens[0]);
            }
        }

        // public void ShowScreen(GameObject screen) {
        //     if (screenHistory.Count > 0) {
        //         screenHistory.Peek().SetActive(false);
        //     }
        //
        //     screen.SetActive(true);
        //     screenHistory.Push(screen);
        // }
        public void ShowScreen(string screenName) {
            if (screenRegistry.ContainsKey(screenName)) {
                HideAllScreens(); 
                GameObject screenToOpen = screenRegistry[screenName];
                screenToOpen.SetActive(true);
            }
            else {
                Debug.LogError("Screen not found: " + screenName);
            }
        }

        public void GoBack() {
            if (screenHistory.Count > 1) {
                screenHistory.Pop().SetActive(false);
                screenHistory.Peek().SetActive(true);
            }
        }

        public void RegisterScreen(string screenName, GameObject screenObject) {
            if (!screenRegistry.ContainsKey(screenName)) {
                screenRegistry.Add(screenName, screenObject);
            }
        }

        private void HideAllScreens() {
            foreach (var screen in screenRegistry.Values) {
                screen.SetActive(false);
            }
        }
    }
}