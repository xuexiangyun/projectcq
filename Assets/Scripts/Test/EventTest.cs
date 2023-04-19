using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

public class EventTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var evt = EnumEventSystem.Global.Register(1, test);
        evt = null;
        EnumEventSystem.Global.UnRegister(1);
    }

    private void test(params object[] obj)
    {
        
    }
    // Update is called once per frame
}
