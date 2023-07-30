using GameUI;
using QFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class UIProgressManage : QMgrBehaviour
{
    public override int ManagerId => QMgrID.UIFilter;

    private void Awake()
    {
        GameApp.Instance.RegisterManage(this);
    }

    public override void Init()
    {
       var init = UIRoot.Instance;
        EnumEventSystem.Global.Register(GamePlayEvnetEnum.SceneLoaded, OnOpenSceneUI);
    }

    private void OnOpenSceneUI(object[] obj)
    {
        GameSceneSO sceneSO = (GameSceneSO)obj[0];
        if(sceneSO.scenesType == ScenesType.Menu)
        {
            //UIKit.CloseAllPanel();
            StartCoroutine(UIKit.OpenPanelAsync<MainPanel>());
        }
    }

    protected override void OnBeforeDestroy()
    {
        Destroy(UIRoot.Instance);
    }
}
