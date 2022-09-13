using UnityEngine;
using Ruinum.Core;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : BaseSingleton<SceneTransition>, IExecute
{
    [SerializeField] private Text LoadingPercentage;

    private static bool shouldPlayOpeningAnimation = false;

    private Animator animator;
    private AsyncOperation loadingSceneOperation;

    public static void SwitchToScene(string sceneName)
    {
        Singleton.animator.SetTrigger("sceneClosing");

        Singleton.loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);

        Singleton.loadingSceneOperation.allowSceneActivation = false;
    }

    public void Execute()
    {   
        if (loadingSceneOperation != null)
        {
            LoadingPercentage.text = "Loading... " + Mathf.RoundToInt(loadingSceneOperation.progress * 100) + "%";
        }
    }

    public void OnAnimationOver()
    {
        shouldPlayOpeningAnimation = true;
        loadingSceneOperation.allowSceneActivation = true;
    }

    private void Start()
    {
        GameManager.Singleton.AddExecuteObject(this);
        animator = GetComponent<Animator>();

        if (shouldPlayOpeningAnimation)
        {
            animator.SetTrigger("sceneOpening");

            shouldPlayOpeningAnimation = false;
        }
    }
}
