using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeAxis : MonoBehaviour
{
    [SerializeField] private InputAction mode_change;

    // Start is called before the first frame update

    private void OnEnable()
    {
        mode_change.Enable();
    }

    private void OnDisable()
    {
        mode_change.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        mode_change.performed += ChangeAxisAction;
    }

    private void ChangeAxisAction(InputAction.CallbackContext context)
    {
        float read = mode_change.ReadValue<float>();

        if (Utility.using_axis < 5 && Utility.using_axis > 0)
        {
            Utility.using_axis += (int)read;
        }
        else if (Utility.using_axis == 5 && read < 0)
        {
            Utility.using_axis--;
        }
        else if (Utility.using_axis == 0 && read > 0)
        {
            Utility.using_axis++;
        }
    }
}
