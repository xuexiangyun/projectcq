using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using System;

public class EventTest : MonoBehaviour
{
    // Start is called before the first frame update
    private readonly Lazy<EnumEventSystem> mEventSystem =
        new Lazy<EnumEventSystem>(ObjectFactory.CreateNonPublicConstructorObject<EnumEventSystem>);
    void Start()
    {

        EnumEventSystem.Global.Send(GamePlayEvnetEnum.SceneFade, FadeStyle.FadeOut);

    }

    private void test(params object[] obj)
    {
        Debug.Log('1');
    }
    // Update is called once per frame
}
