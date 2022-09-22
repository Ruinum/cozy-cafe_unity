using UnityEngine;
using UnityEngine.SceneManagement;

using Ruinum.Core;


public class GameplaySceneLoader : BaseSingleton<GameplaySceneLoader>
{
    [SerializeField] private int _topologySceneIndex;

    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadGameplay();
    }

    public void LoadGameplay()
    {
        SceneManager.LoadSceneAsync(_topologySceneIndex, LoadSceneMode.Additive);
    }
}
