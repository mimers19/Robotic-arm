using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour
{
    private Color basic_color;
    [SerializeField] Text recordButton;

    // Start is called before the first frame update
    void Start()
    {
        basic_color = recordButton.color;
    }

    public void OnClick()
    {
        Utility.recording = !Utility.recording;

        if (Utility.recording)
        {
            recordButton.color = Color.red;
            for (int i = 0; i < 6; i++)
            {
                Utility.recorded_angles[i].Clear();
            }
        }
        else
            recordButton.color = basic_color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Utility.recording)
        {
            save_angles();
        }
    }

    private void save_angles()
    {
        for (int i = 0;i < 6;i++)
        {
            Utility.recorded_angles[i].Add(Utility.axis_angle[i]);
        }
    }

}
