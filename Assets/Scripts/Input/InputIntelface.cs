using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputIntelface : QMonoBehaviour
{
    public override IManager Manager => ScenesManage.Instance;

    protected virtual void ReleaseInputListen() { }

    protected virtual void AddInputListen() { }

    private void Awake()
    {
        AddInputListen();
    }

    protected override void OnBeforeDestroy()
    {
        ReleaseInputListen();
    }

}
