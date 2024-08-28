using System;
using UnityEngine;

namespace CodeBase.SceneManager {
    public class LoaderCallBack : MonoBehaviour {
        private bool IsFirstUpdate = true;

        private void Update() {
            if (IsFirstUpdate) {
                IsFirstUpdate = false;
                Invoke("InvokeLoaderCallback", 1f);
            }
        }

        private void InvokeLoaderCallback() {
            Loader.LoaderCallBack();
        }
    }
}