using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PresetRotation : MonoBehaviour
{
    [SerializeField] TMP_InputField axis0_angle;
    [SerializeField] TMP_InputField axis1_angle;
    [SerializeField] TMP_InputField axis2_angle;
    [SerializeField] TMP_InputField axis3_angle;
    [SerializeField] TMP_InputField axis4_angle;
    [SerializeField] TMP_InputField axis5_angle;

    [SerializeField] private GameObject axis_point0;
    [SerializeField] private GameObject axis_rotation0;
    [SerializeField] private GameObject arm0;
    [SerializeField] private Axis basic_movement0;
    [SerializeField] private float rotationSpeed0;
    [SerializeField] private int axis_index0;
    [SerializeField] private int rotation_min0;
    [SerializeField] private int rotation_max0;

    [SerializeField] private GameObject axis_point1;
    [SerializeField] private GameObject axis_rotation1;
    [SerializeField] private GameObject arm1;
    [SerializeField] private Axis basic_movement1;
    [SerializeField] private float rotationSpeed1;
    [SerializeField] private int axis_index1;
    [SerializeField] private int rotation_min1;
    [SerializeField] private int rotation_max1;

    [SerializeField] private GameObject axis_point2;
    [SerializeField] private GameObject axis_rotation2;
    [SerializeField] private GameObject arm2;
    [SerializeField] private Axis basic_movement2;
    [SerializeField] private float rotationSpeed2;
    [SerializeField] private int axis_index2;
    [SerializeField] private int rotation_min2;
    [SerializeField] private int rotation_max2;

    [SerializeField] private GameObject axis_point3;
    [SerializeField] private GameObject axis_rotation3;
    [SerializeField] private GameObject arm3;
    [SerializeField] private Axis basic_movement3;
    [SerializeField] private float rotationSpeed3;
    [SerializeField] private int axis_index3;
    [SerializeField] private int rotation_min3;
    [SerializeField] private int rotation_max3;

    [SerializeField] private GameObject axis_point4;
    [SerializeField] private GameObject axis_rotation4;
    [SerializeField] private GameObject arm4;
    [SerializeField] private Axis basic_movement4;
    [SerializeField] private float rotationSpeed4;
    [SerializeField] private int axis_index4;
    [SerializeField] private int rotation_min4;
    [SerializeField] private int rotation_max4;

    [SerializeField] private GameObject axis_point5;
    [SerializeField] private GameObject axis_rotation5;
    [SerializeField] private GameObject arm5;
    [SerializeField] private Axis basic_movement5;
    [SerializeField] private float rotationSpeed5;
    [SerializeField] private int axis_index5;
    [SerializeField] private int rotation_min5;
    [SerializeField] private int rotation_max5;

    public static float[] angle = { 0, 0, 0, 0, 0, 0 };

    public static bool rotation = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnClick()
    {
        rotation = true;
        try
        {
            angle[0] = float.Parse(axis0_angle.text);
        } catch
        {
            angle[0] = Utility.axis_angle[0];
        }

        try
        {
            angle[1] = float.Parse(axis1_angle.text);
        }
        catch
        {
            angle[1] = Utility.axis_angle[1];
        }

        try
        {
            angle[2] = float.Parse(axis2_angle.text);
        }
        catch
        {
            angle[2] = Utility.axis_angle[2];
        }

        try
        {
            angle[3] = float.Parse(axis3_angle.text);
        }
        catch
        {
            angle[3] = Utility.axis_angle[3];
        }

        try
        {
            angle[4] = float.Parse(axis4_angle.text);
        }
        catch
        {
            angle[4] = Utility.axis_angle[4];
        }

        try
        {
            angle[5] = float.Parse(axis5_angle.text);
        }
        catch
        {
            angle[5] = Utility.axis_angle[5];
        }

    }

    // Update is called once per frame
    void Update()
    {
        Rotate(axis_point0, axis_rotation0, arm0, basic_movement0, rotationSpeed0, axis_index0, rotation_min0, rotation_max0, 0);
        Rotate(axis_point1, axis_rotation1, arm1, basic_movement1, rotationSpeed1, axis_index1, rotation_min1, rotation_max1, 1);
        Rotate(axis_point2, axis_rotation2, arm2, basic_movement2, rotationSpeed2, axis_index2, rotation_min2, rotation_max2, 2);
        Rotate(axis_point3, axis_rotation3, arm3, basic_movement3, rotationSpeed3, axis_index3, rotation_min3, rotation_max3, 3);
        Rotate(axis_point4, axis_rotation4, arm4, basic_movement4, rotationSpeed4, axis_index4, rotation_min4, rotation_max4, 4);
        Rotate(axis_point5, axis_rotation5, arm5, basic_movement5, rotationSpeed5, axis_index5, rotation_min5, rotation_max5, 5);
    }

    private void Rotate(GameObject axis_point, GameObject axis_rotation, GameObject arm, Axis basic_movement, float rotationSpeed, int axis_index,  int rotation_min, int rotation_max, int rotation_counter_indeks)
    {
        Quaternion base_rotation = axis_rotation.transform.rotation;
        Vector3 rotate = MakeVectorFromAxis(basic_movement, arm);
        float direction = (angle[rotation_counter_indeks] - Utility.axis_angle[rotation_counter_indeks]) / Math.Abs(angle[rotation_counter_indeks] - Utility.axis_angle[rotation_counter_indeks]);
        float to_angle = (direction * Time.deltaTime)*rotationSpeed;
        rotate = base_rotation * rotate;
        float bufor = Utility.axis_angle[rotation_counter_indeks] + to_angle;
        if (bufor >= rotation_min && bufor <= rotation_max && rotation)
        {
            if (EveryMoveIsFinished())
            {
                rotation = false;
            }
            else
            {
                Utility.axis_angle[axis_index] = Utility.axis_angle[rotation_counter_indeks];
                Utility.axis_angle[rotation_counter_indeks] += to_angle;
                arm.transform.RotateAround(axis_point.transform.position, rotate, to_angle);
            }
                

        }
    }

    private Vector3 MakeVectorFromAxis(Axis axis, GameObject arm)
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

    private bool Approx(float x, float accurancy, float wanted)
    {
        if (x < accurancy + wanted && x > wanted - accurancy)
            return true;
        else
            return false;
    }

    private bool EveryMoveIsFinished()
    {
        for (int i = 0; i < 6; i++)
        {
            if (!Approx(Utility.axis_angle[i], (float)0.1, angle[i]))
            {
                return false;
            }
        }
        return true;
    }
}
