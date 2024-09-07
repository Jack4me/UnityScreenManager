using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour {
    private static ScreenManager instance;
    public Stack<GameObject> screenHistory = new Stack<GameObject>();

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
    }

    public GameObject mainMenuScreen;
    public GameObject settingsScreen;
    public GameObject pauseMenuScreen;
    public GameObject shopScreen;


    public void ShowScreen(string panelName) {
        // Сначала скрываем все панели
        HideAllPanels();

        GameObject screen = null; // Для хранения текущего экрана

        // Находим нужную панель по имени
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
            screenHistory.Peek().SetActive(false);
                Debug.LogError("screenHistory.Count 0" );
        }

       
        screen.SetActive(true);
        screenHistory.Push(screen);
    }

    private void HideAllPanels() {
        mainMenuScreen.SetActive(false);
        settingsScreen.SetActive(false);
    }
    public void GoBack()
    {
        if (screenHistory.Count > 1)
        {
                Debug.LogError("screenHistory.Count 01" );
            screenHistory.Pop().SetActive(false);
            screenHistory.Peek().SetActive(true);
        }
    }
}