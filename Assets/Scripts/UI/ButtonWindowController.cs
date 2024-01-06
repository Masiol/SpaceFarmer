using UnityEngine;
using UnityEngine.UI;

public class ButtonWindowController : MonoBehaviour
{
    public GameObject windowPrefab;

    private void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OpenWindow);
        }
    }

    private void OpenWindow()
    {
        UIWindowManager.instance.CreateWindow(windowPrefab);
    }
}