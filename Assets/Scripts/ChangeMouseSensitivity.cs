using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMouseSensitivity : MonoBehaviour
{
    public Slider sensitivitySlider;

    public void ApplySensitivity()
    {
        GetComponent<FPSControllerLPFP.FpsControllerLPFP>().mouseSensitivity = sensitivitySlider.value;
    }
}
