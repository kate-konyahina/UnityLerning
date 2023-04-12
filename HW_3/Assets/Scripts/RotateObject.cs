using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateObject : MonoBehaviour
{

    [SerializeField] GameObject obj;
    [SerializeField] Slider slider;

    public void OnSliderValueChanged()
    {
        var value = slider.value;
        var rotation = value * 360;
        obj.transform.localRotation = Quaternion.Euler(new Vector3(rotation,0, 0));
    }
}
