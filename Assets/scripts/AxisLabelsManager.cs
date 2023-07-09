
using UnityEngine;
using UnityEngine.UI;

public class AxisLabelsManager : MonoBehaviour
{
    [SerializeField] Text axis_label;
    [SerializeField] Text axis_angle;
    [SerializeField] Text tool_x;
    [SerializeField] Text tool_y;
    [SerializeField] Text tool_z;
    [SerializeField] GameObject tool;

    private Vector3 coords;

    // Start is called before the first frame update
    void Start()
    {
        coords = tool.transform.position;

        tool_x.text = "X: 0";
        tool_y.text = "Y: 0";
        tool_z.text = "Z: 0";
    }

    // Update is called once per frame
    void Update()
    {
        axis_label.text = "Axis: " + (Utility.using_axis + 1).ToString();
        axis_angle.text = Utility.axis_angle[Utility.using_axis].ToString();
        tool_x.text = "X: " + (tool.transform.position.x - coords.x).ToString();
        tool_y.text = "Y: " + (tool.transform.position.y - coords.y).ToString();
        tool_z.text = "Z: " + (tool.transform.position.z - coords.z).ToString();
    }
}
