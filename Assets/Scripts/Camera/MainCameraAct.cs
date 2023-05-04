using QFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MainCameraAct : MonoBehaviour
{
    private Camera _camera;
    //
    private void Awake()
    {
        _camera = GetComponent<Camera>();
        var _cameraData = _camera.GetUniversalAdditionalCameraData();
        var _uiCamera = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
        if(_uiCamera)
            _cameraData.cameraStack.Add(_uiCamera);
    }

    private void OnDestroy()
    {
        var _cameraData = _camera.GetUniversalAdditionalCameraData();
        var _cameracount = _cameraData.cameraStack.Count;
        if (_cameraData.cameraStack.Count > 0)
            _cameraData.cameraStack.RemoveRange(0, _cameracount);
    }
}
