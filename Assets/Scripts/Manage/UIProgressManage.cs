using QFramework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class UIProgressManage : MonoBehaviour, IManage
{
    private void Awake()
    {
        GameApp.Instance.RegisterManage(this);
    }

    public void Initialization()
    {
       var init = UIRoot.Instance;
    }

    public void OnDestroy()
    {
        Destroy(UIRoot.Instance);
    }
}
