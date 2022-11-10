using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{

    [SerializeField] float transitionTime;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] AnimationCurve curve;
    Coroutine transitionRoutine;

    void Start()
    {
        StartTransition(0, 1, 0);
    }

    private void StartTransition(int sceneValue, float startValue, float endValue)
    {
        if (transitionRoutine == null)
        {
            transitionRoutine = StartCoroutine(Transition(sceneValue, startValue, endValue));
        }
    }

    IEnumerator Transition(int sceneValue, float startValue, float endValue)
    {

        float elapsedTime = 0;

        while (transitionTime > elapsedTime)
        {
            canvasGroup.alpha = Mathf.Lerp(startValue, endValue, curve.Evaluate(elapsedTime / transitionTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = endValue;
        transitionRoutine = null;

        if (sceneValue == 1 || sceneValue == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneValue);
        }
        yield return null;

    }
}
