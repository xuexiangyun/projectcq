using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
public class GameApp : Singleton<GameApp>
{
    public bool inited { get; private set; }
    private IOCContainer ModelIoc;
    private IOCContainer ManageIoc;

    public GameApp() { }
    public void Init() { }
    public override void OnSingletonInit()
    {
        ModelIoc = new IOCContainer();
        ManageIoc = new IOCContainer();

        //------初始化完成------
        inited = true;
    }

    public T GetModel<T>() where T : class
    {
        return ModelIoc.Get<T>();
    }

    public void RegisterModel<T>(T instance) where T:IData
    {
        ModelIoc.Register<T>(instance);
        instance.Initialization();
    }

    public T GetManage<T>() where T : class
    {
        return ManageIoc.Get<T>();
    }

    public void RegisterManage<T>(T instance) where T:IManage
    {
        ManageIoc.Register<T>(instance);
        instance.Initialization();
    }
}
