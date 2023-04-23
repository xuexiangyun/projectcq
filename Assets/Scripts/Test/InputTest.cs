using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class InputTest : MonoBehaviour
{
    private InputMange input;
    public Transform objTrf;
    private void Start()
    {
        input = GetComponent<InputMange>();
        input.onMovement.Register(onMove);
        input.onJump.Register(onJump);
        input.SwitchbleAllAction(true);
    }


    private void onMove(CallbackContext context)
    {
        var _mvalue =  context.ReadValue<float>();
        Debug.Log(_mvalue);
    }

    private void onJump(CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
            Debug.Log("jump");
    }

}
