using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour {
    private static ScreenManager instance;

    public GameObject mainMenuScreen;
    public GameObject settingsScreen;
    public GameObject ShopScreen;

    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ShowPanel(string panelName) {
//        mainMenuPanel.SetActive(false);
        settingsScreen.SetActive(false);
        //    pauseMenuPanel.SetActive(false);
        HideAllPanels();
        switch (panelName) {
            case "MainMenu":
                mainMenuScreen.SetActive(true);
                break;
            case "Settings":
                settingsScreen.SetActive(true);
                break;
            case "PauseMenu":
                ShopScreen.SetActive(true);
                break;
            default:
                Debug.LogError("Unknown panel: " + panelName);
                break;
        }
    }

    private void HideAllPanels() {
        // Отключаем все панели
        mainMenuScreen.SetActive(false);
        settingsScreen.SetActive(false);
        ShopScreen.SetActive(false);
    }
}