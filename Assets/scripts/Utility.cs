using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Utility : MonoBehaviour
{
    public static bool recording = false;
    public static bool playing = false;
    public static int using_axis = 0;
    public static float[] axis_angle = { 0, 0, 0, 0, 0, 0 };
    [SerializeField] private float zoom_speed;
    [SerializeField] private Camera cam;
    public InputAction zoom;
    public static List<float>[] recorded_angles = new List<float>[6];

    private void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            recorded_angles[i] = new List<float>();
        }
    }

    private void OnEnable()
    {
        zoom.Enable();
    }

    private void OnDisable()
    {
        zoom.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        float read = zoom.ReadValue<float>();
        float buffor = cam.fieldOfView + (read * zoom_speed);

        if(buffor < 60 &&  buffor > 15 ) 
        {
            cam.fieldOfView = cam.fieldOfView + (read * zoom_speed);
        }

        //Vector3 translation = cam.transform.position.normalized + cam.transform.position.normalized * zoom_speed * read;
    }
}
