using UnityEngine;
using DG.Tweening;

public class Window : MonoBehaviour, IObservableWindow
{
    public float closeAnimationDuration = 1.0f;
    public float openAnimationDuration = 1.0f;

    public Ease ease;

    private BackManager backManager;

    private void Start()
    {
        backManager = BackManager.instance;
        this.transform.localScale = Vector3.zero;
        
        OpenWindow();
    }

    public void OpenWindow()
    {
        this.transform.DOScale(Vector3.one, openAnimationDuration).SetEase(ease);
    }

    public void OnCloseWindow()
    {
        backManager.UnregisterWindow(this);
        CloseWindow();
    }

    private void CloseWindow()
    {
        this.transform.DOScale(Vector3.zero, openAnimationDuration).SetEase(ease).OnComplete(() =>
        {
            Destroy(gameObject);
        });
        
    }
}
