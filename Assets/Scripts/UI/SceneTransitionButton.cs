using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransitionButton : MonoBehaviour
{
    public string targetSceneName;

    public void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }
    }

    private void OnClick()
    {
        SceneTransitionManager.Instance.TransitionToScene(targetSceneName);
    }
}