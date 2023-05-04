using UnityEngine;
using QFramework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using GameUI;

public class ScenesManage : QMgrBehaviour
{
    private GameSceneSO _loadToScene;
    private GameSceneSO _curScnene;
    private bool _showLoadPage;
    private bool _nextFadePage;
    private bool _backFadePage;

    public GameSceneSO CurScene => _curScnene;

    public override int ManagerId => QMgrID.Scenes;

    private bool _isLoading = false;


    private void Awake()
    {
        GameApp.Instance.RegisterManage(this);
    }

    private void LoadScene(object[] objects)
    {
        if (_isLoading) return;
        SceneArgs args = (SceneArgs)objects[0];

        _loadToScene = args.sceneSO;
        _showLoadPage = args.ShowLoadingPage;
        _nextFadePage = args.NextFadePage;
        _backFadePage = args.BackFadePage;
        _isLoading = true;
        StartCoroutine(UnloadPreviousScene());
    }

    private IEnumerator UnloadPreviousScene()
    {
        if (_backFadePage)
        {
            EnumEventSystem.Global.Send(GamePlayEvnetEnum.SceneFade, FadeStyle.FadeOut);
            yield return new WaitForSeconds(FadeCanvas.fadeTime);
        }
        if (_curScnene != null && _curScnene.sceneReference.OperationHandle.IsValid()){
            _curScnene.sceneReference.UnLoadScene();
            _curScnene = null;
        }
        LoadNewScene();
    }

    private void LoadNewScene()
    {

        if (_loadToScene != null)
        {
            var handle1 = _loadToScene.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true, 0);
            handle1.Completed += OnLoadedScene;
            if (_showLoadPage)
            {
                EnumEventSystem.Global.Send(GamePlayEvnetEnum.LoadingPageView, handle1);
            }
        }
        else
        {
            Debug.Log("load³¡¾°Îª¿Õ");
        }
    }

    private void OnLoadedScene(AsyncOperationHandle<SceneInstance> obj)
    {
        _curScnene = _loadToScene;
        _isLoading = false;
        if (_nextFadePage)
        {
            EnumEventSystem.Global.Send(GamePlayEvnetEnum.SceneFade, FadeStyle.FadeOut);
        }
        EnumEventSystem.Global.Send(GamePlayEvnetEnum.SceneLoaded, CurScene);
    }

    public override void Init()
    {
        EnumEventSystem.Global.Register(GamePlayEvnetEnum.SceneLoad, LoadScene);
    }

    protected override void OnBeforeDestroy()
    {
        EnumEventSystem.Global.UnRegister(GamePlayEvnetEnum.SceneLoad, LoadScene);
    }
}
