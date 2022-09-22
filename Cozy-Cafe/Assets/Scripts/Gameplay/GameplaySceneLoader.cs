using UnityEngine;
using UnityEngine.SceneManagement;

using Ruinum.Core;


public class GameplaySceneLoader : BaseSingleton<GameplaySceneLoader>
{
    [SerializeField] private int _topologySceneIndex;
    [SerializeField] private int _uiSceneIndex;

    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);
    }

    public void LoadGameplay()
    {
        SceneManager.LoadSceneAsync(_topologySceneIndex, LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync(_uiSceneIndex, LoadSceneMode.Additive);
    }
}
