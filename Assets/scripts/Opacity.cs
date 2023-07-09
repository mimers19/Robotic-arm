using UnityEngine;
using UnityEngine.UI;

public class Opacity : MonoBehaviour
{
    public Image image; // Reference to the Image component

    void Start()
    {
        ChangeOpacity();
    }

    public void ChangeOpacity()
    {
        Color color = image.color; // Get the current color of the Image component

        // Set the alpha value to 0.5 (50% opacity)
        color.a = 0.45f;

        // Apply the new color with changed opacity to the Image component
        image.color = color;
    }
}