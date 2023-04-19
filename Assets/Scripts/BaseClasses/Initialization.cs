using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using QFramework;

public class Initialization :MonoBehaviour
{
    [SerializeField] private GameSceneSO persistentScene;
    [SerializeField] private GameSceneSO mainScene;

    private void Start()
    {
        StarGame();
    }

    private void StarGame()
    {
        GameApp.Instance.Init();
        persistentScene.sceneReference.LoadSceneAsync(LoadSceneMode.Additive).Completed += LoadMainMenu;
    }

    private void LoadMainMenu(AsyncOperationHandle<SceneInstance> obj)
    {
        EnumEventSystem.Global.Send(GamePlayEvnetEnum.SceneLoad, new SceneArgs(mainScene));
        SceneManager.UnloadSceneAsync(0);
    }
}
