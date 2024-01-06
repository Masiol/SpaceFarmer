using UnityEngine;

public class Window : MonoBehaviour, IObservableWindow
{
    public float closeAnimationDuration = 1.0f;

    private BackManager backManager;

    private void Start()
    {
        backManager = BackManager.instance;
        this.transform.localScale = Vector3.zero;
        OpenWindow();
    }

    public void OpenWindow()
    {
        this.transform.localScale = Vector3.one;
    }

    public void OnCloseWindow()
    {
        backManager.UnregisterWindow(this);
        CloseWindow();
    }

    private void CloseWindow()
    {
        Destroy(gameObject);
    }
}
