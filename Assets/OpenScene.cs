
using UnityEngine;
using UnityEngine.UI;

public class OpenScene : MonoBehaviour
{
    [SerializeField] private string screenName;
    [SerializeField] private Button OpenWindowButton;
    private void Start() {
        OpenWindowButton.onClick.AddListener( );
    }
}
