using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArmRotation1 : MonoBehaviour
{
    [SerializeField] private GameObject axis_point;
    //[SerializeField] private GameObject axis_rotation;
    [SerializeField] private GameObject arm;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private int rotation_min;
    [SerializeField] private int rotation_max;
    private int axis_index = 0;
    private float rotation_counter = 0;

    public InputAction ctrl;

    private void OnEnable()
    {
        ctrl.Enable();
    }

    private void OnDisable()
    {
        ctrl.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Utility.using_axis == axis_index)
        {
            float read = ctrl.ReadValue<float>();
            float bufor = rotation_counter + (float)(rotationSpeed * read * Time.deltaTime);
            if (bufor >= rotation_min && bufor <= rotation_max && !Utility.playing) 
            {
                rotation_counter = bufor;
                float rotation = (float)(rotationSpeed * read * Time.deltaTime);
                arm.transform.RotateAround(axis_point.transform.position, new Vector3(0, 1, 0), rotation);
                Utility.axis_angle[0] += rotation;
            }
        }
    }
}
