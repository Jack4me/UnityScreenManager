using UnityEngine;

namespace CodeBase.ScreenManager {
   public class CloseButton : MonoBehaviour {
      public GameObject window;


      public void CloseWindow() {
         window.SetActive(false);
      }
   }
}
