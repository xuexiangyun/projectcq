
    /* ����¼�1-99 */
   public enum FrameEvnetEnum { 
        START = 0,
        ApplicationQuit,
        END = 100
    }

    /* ��Ϸ�¼�101-9999 */
   public enum GamePlayEvnetEnum
    {
        START = 100,
        KitInited,
        SceneLoad,
        SceneLoaded,
        SceneFade,
        LoadingPageView,
        END = 10000
    }

    /* �����¼���ʼ10001 */
  public enum NetWorkEventEnum
    {
        START = 10000,

    }


public enum FadeStyle
{
    FadeIn,
    FadeOut
}