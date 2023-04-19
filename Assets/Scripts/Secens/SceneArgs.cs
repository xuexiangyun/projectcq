
public struct SceneArgs
{
    private GameSceneSO _sceneSO;
    private bool _nextFadePage;
    private bool _backFadePage;
    private bool _showLoadingPage;

    public GameSceneSO sceneSO => _sceneSO;
    //进入场景时渐入
    public bool NextFadePage => _nextFadePage;
    //退出场景时渐出
    public bool BackFadePage => _backFadePage;
    //场景过度加载界面
    public bool ShowLoadingPage => _showLoadingPage;

    public SceneArgs(GameSceneSO so,bool showLoadingPage = false, bool nextFadePage = false,bool backFadePage = false)
    {
        this._sceneSO = so;
        this._showLoadingPage = showLoadingPage;
        this._nextFadePage = nextFadePage;
        this._backFadePage = backFadePage;
    }
}
