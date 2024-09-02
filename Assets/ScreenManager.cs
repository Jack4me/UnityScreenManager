using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour {
    private static ScreenManager instance;

    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public GameObject pauseMenuPanel;

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
        settingsPanel.SetActive(false);
    //    pauseMenuPanel.SetActive(false);

        switch (panelName) {
            case "MainMenu":
                mainMenuPanel.SetActive(true);
                break;
            case "Settings":
                settingsPanel.SetActive(true);
                break;
            case "PauseMenu":
                pauseMenuPanel.SetActive(true);
                break;
            default:
                Debug.LogError("Unknown panel: " + panelName);
                break;
        }
    }
}