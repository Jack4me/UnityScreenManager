using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.ScreenManager {
    public class OpenScreen : MonoBehaviour {
        [SerializeField] private GameObject ScreenName;
        [SerializeField] private Button OpenWindowButton;

        private void Start() {
            OpenWindowButton.onClick.AddListener(OnOpenHUDButtonClick);
        }

        private void OnOpenHUDButtonClick() {
            ScreenManager.instance.ShowScreen(ScreenName);
        }
    }
}