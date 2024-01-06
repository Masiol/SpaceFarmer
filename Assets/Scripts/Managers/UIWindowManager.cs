using UnityEngine;

public class UIWindowManager : MonoBehaviour
{
    public static UIWindowManager instance;

    public Transform windowsParent; // Rodzic dla utworzonych okien

    private void Awake()
    {
        instance = this;
    }

    public void CreateWindow(GameObject windowPrefab)
    {
        GameObject windowObject = Instantiate(windowPrefab, windowsParent);
        IObservableWindow observableWindow = windowObject.GetComponent<IObservableWindow>();

        if (observableWindow != null)
        {
            BackManager.instance.RegisterWindow(observableWindow);
        }
    }
}
