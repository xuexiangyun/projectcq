using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static GameInput;
using static UnityEngine.InputSystem.InputAction;

public class InputMange : QMgrBehaviour, IGamePlayActions, IUIActions
{
    private GameInput gameInput;

    public override int ManagerId => QMgrID.Input;

    private void Awake()
    {
        GameApp.Instance.RegisterManage(this);
    }

    private void OnEnable()
    {
        if (gameInput == null)
        {
            gameInput = new GameInput();
            gameInput.GamePlay.SetCallbacks(this);
            gameInput.UI.SetCallbacks(this);
        }
    }

    private void OnDisable()
    {
        SwitchbleAllAction(false);
    }

    public void SwitchbleAllAction(bool enable)
    {
        SwitchGamePlayerAction(enable);
        SwitchUIAction(enable);
    }

    public void SwitchGamePlayerAction(bool enable)
    {
        if (enable)
        {
            gameInput.GamePlay.Enable();
        }
        else
        {
            gameInput.GamePlay.Disable();

        }
    }

    public void SwitchUIAction(bool enable)
    {
        if (enable)
        {
            gameInput.UI.Enable();
        }
        else
        {
            gameInput.UI.Disable();

        }
    }

    #region Gameplay

    public EasyEvent<CallbackContext> onFire = new EasyEvent<CallbackContext>();
    public EasyEvent<CallbackContext> onInteraction = new EasyEvent<CallbackContext>();
    public EasyEvent<CallbackContext> onJump = new EasyEvent<CallbackContext>();
    public EasyEvent<CallbackContext> onMovement = new EasyEvent<CallbackContext>();
    public EasyEvent<CallbackContext> onPause = new EasyEvent<CallbackContext>();
    public EasyEvent<CallbackContext> onSkill = new EasyEvent<CallbackContext>();

    //已下来自inputsystem
    public void OnFire(CallbackContext context)
    {
        onFire.Trigger(context);
    }

    public void OnInteraction(CallbackContext context)
    {
        onInteraction.Trigger(context);
    }

    public void OnJump(CallbackContext context)
    {
        onJump.Trigger(context);
    }

    public void OnMovement(CallbackContext context)
    {
        onMovement.Trigger(context);
    }

    public void OnPause(CallbackContext context)
    {
        onPause.Trigger(context);
    }

    public void OnSkill(CallbackContext context)
    {
        onSkill.Trigger(context);
    }
    #endregion

    #region UI
    public void OnNavigate(CallbackContext context)
    {

    }

    public void OnSubmit(CallbackContext context)
    {

    }

    public void OnCancel(CallbackContext context)
    {

    }

    public void OnPoint(CallbackContext context)
    {

    }

    public void OnClick(CallbackContext context)
    {

    }

    public void OnScrollWheel(CallbackContext context)
    {

    }

    public void OnMiddleClick(CallbackContext context)
    {

    }

    public void OnRightClick(CallbackContext context)
    {

    }

    public void OnTrackedDevicePosition(CallbackContext context)
    {

    }

    public void OnTrackedDeviceOrientation(CallbackContext context)
    {

    }
    #endregion
}
