using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;

    [SerializeField] private RectTransform leftImage;
    [SerializeField] private RectTransform rightImage;
    [SerializeField] private float transitionTime = 1.0f;

    private float screenWidth;
    private const float TransitionWaitTime = 1.75f;
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return; // Exit early if duplicate
        }

        screenWidth = Screen.width / 1.5f;
        SetStartImagesPosition();
    }  
    private void SetStartImagesPosition()
    {
        SetImagePosition(leftImage, -screenWidth, 0);
        SetImagePosition(rightImage, screenWidth, 0);
    }   
    private void SetImagePosition(RectTransform image, float offsetX, float duration)
    {
        DOTween.To(() => image.offsetMax.x, x => image.offsetMax = new Vector2(x, image.offsetMax.y), offsetX, duration)
            .SetEase(Ease.InQuad);
        DOTween.To(() => image.offsetMin.x, x => image.offsetMin = new Vector2(x, image.offsetMin.y), offsetX, duration)
            .SetEase(Ease.InQuad);
    }
    public void TransitionToScene(string sceneName)
    {
        StartCoroutine(TransitionCoroutine(sceneName));
    }
   
    private IEnumerator TransitionCoroutine(string sceneName)
    {
        yield return StartCoroutine(FadeIn());

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        yield return StartCoroutine(FadeOut());
    }
    private IEnumerator FadeIn()
    {
        SetImagePosition(rightImage, 0, transitionTime);
        SetImagePosition(leftImage, 0, transitionTime);
        yield return new WaitForSeconds(TransitionWaitTime);
    }
    private IEnumerator FadeOut()
    {
        SetImagePosition(rightImage, screenWidth, transitionTime);
        SetImagePosition(leftImage, -screenWidth, transitionTime);    
        yield return new WaitForSeconds(TransitionWaitTime);
    }
   

    
    
}
