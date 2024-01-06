using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackManager : MonoBehaviour, IBackManager
{
    public static BackManager instance;
    private List<IObservableWindow> observableWindows = new List<IObservableWindow>();

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void RegisterWindow(IObservableWindow observable)
    {
        if (!observableWindows.Contains(observable))
        {
            observableWindows.Add(observable);
        }
    }

    public void UnregisterWindow(IObservableWindow observable)
    {
        if(observableWindows.Contains(observable))
        {
            observableWindows.Remove(observable);
        }
    } 
    public void HandleBack()
    {
        if(observableWindows.Count > 0)
        {
            var lastObserver = observableWindows[observableWindows.Count - 1];
            {
                lastObserver.OnCloseWindow();
            }

        }
    }
}
