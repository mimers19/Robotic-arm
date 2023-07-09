using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject robot;
    [SerializeField] private float min_angle;
    [SerializeField] private float max_angle;
    private Vector3 previousPosition;


    private void Awake()
    {
        //Vector3 translateVector = new Vector3(robot.transform.position.x, robot.transform.position.y + 1, robot.transform.position.z-7);
        //cam.transform.Translate(translateVector);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = previousPosition - cam.ScreenToViewportPoint(Input.mousePosition);

            cam.transform.position = new Vector3();
            Vector3 translateVector = new Vector3(robot.transform.position.x, (float)(robot.transform.position.y + 1.2), robot.transform.position.z);
            cam.transform.Translate(translateVector);



            cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
            cam.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);
            
            cam.transform.Translate(new Vector3(0, 0, -7));

            if (cam.transform.position.y < min_angle || cam.transform.position.y > max_angle)
            {
                cam.transform.Translate(new Vector3(0, 0, 7));

                cam.transform.Rotate(new Vector3(1, 0, 0), -direction.y * 180);
                cam.transform.Rotate(new Vector3(0, 1, 0), direction.x * 180, Space.World);

                cam.transform.Translate(new Vector3(0, 0, -7));
            }

            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
    }
}
