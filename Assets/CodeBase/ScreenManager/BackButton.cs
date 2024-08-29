using System.Collections;
using System.Collections.Generic;
using CodeBase.SceneManager;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [SerializeField] private Button backButton; 

    private void Start() {
        backButton.onClick.AddListener(OnBackButtonClicked);
    }

    private void OnBackButtonClicked() {
        Loader.LoadPreviousScene(useLoadingScreen: false); 
    }
    
    
}
