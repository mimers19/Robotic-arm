using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ArmRotation2 : MonoBehaviour
{
    [SerializeField] private GameObject axis_point;
    [SerializeField] private GameObject axis_rotation;
    [SerializeField] private GameObject arm;
    [SerializeField] private Axis basic_movement;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private int axis_index;
    [SerializeField] private int rotation_min;
    [SerializeField] private int rotation_max;

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
            Quaternion base_rotation = axis_rotation.transform.rotation;
            Vector3 rotate = MakeVectorFromAxis(basic_movement);
            rotate = base_rotation * rotate;
            float delta_alpha = (float)(rotationSpeed * read * Time.deltaTime);
            float bufor = rotation_counter + delta_alpha;
            if (bufor >= rotation_min && bufor <= rotation_max && !Utility.playing)
            {
                rotation_counter = bufor;
                arm.transform.RotateAround(axis_point.transform.position, rotate, delta_alpha);
                Utility.axis_angle[axis_index] += delta_alpha;
            }
        }
    }

    private Vector3 MakeVectorFromAxis(Axis axis)
    {
        if (axis == Axis.X)
            return new Vector3(0, 0, 1);
        else if (axis == Axis.Y)
            return new Vector3(0, 1, 0);
        else if (axis == Axis.Z)
            return new Vector3(1, 0, 0);
        else
        {
            Debug.Log("B³¹d obrotu - oœ" + arm.name.ToString());
            return new Vector3(0, 0, 0);
        }
    }
}
