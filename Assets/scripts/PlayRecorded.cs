using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayRecorded : MonoBehaviour
{

    private int move_indeks = 0;
    [SerializeField] Text playButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClick()
    {

            Utility.playing = !Utility.playing;
            PresetRotation.rotation = true;

            if (Utility.playing)
            {
                playButton.color = Color.red;
                GoToPosition(GetPosition());
            }
            else
                playButton.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if (Utility.playing && !PresetRotation.rotation && move_indeks < Utility.recorded_angles[0].Count)
        {
            move_indeks++;
            GoToPosition(GetPosition());
            PresetRotation.rotation = true;

            if (Utility.recorded_angles[0].Count - 1 == move_indeks)
            {
                move_indeks = 0;
                PresetRotation.rotation = false;
                Utility.playing = false;
                playButton.color = Color.black;
            }
        }
    }

    private void GoToPosition(float[] new_angles)
    {
        for (int i = 0; i < 6; i++) 
        {
            PresetRotation.angle[i] = new_angles[i];
        }
    }

    private float[] GetPosition()
    {
        float[] angles = new float[6];
        for (int i = 0; i < 6; i++) 
        {
            angles[i] = Utility.recorded_angles[i][move_indeks];
        }

        return angles;
    }
}
