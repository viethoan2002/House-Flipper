using UnityEngine;
using UnityEngine.UI;

public class CanvasScalerFitter : MonoBehaviour
{
    void Start()
    {
        var canvasScaler = GetComponent<CanvasScaler>();
        var ratio = (float)Screen.height / (float)Screen.width;
        //Debug.Log("ratio: " + ratio);
        if (ratio >= 1.78f) //if (ratio > 1.8f)
        {
            canvasScaler.matchWidthOrHeight = 0;
        }
        else canvasScaler.matchWidthOrHeight = 1;
    }
}