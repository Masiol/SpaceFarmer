using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBackManager
{
    void RegisterWindow(IObservableWindow observable);
    void UnregisterWindow(IObservableWindow observable);
    void HandleBack();
}
