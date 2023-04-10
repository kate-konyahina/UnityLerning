using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowInfo : MonoBehaviour
{
    [SerializeField] GameObject _obj;
    [SerializeField] TextMeshProUGUI _text;

    private void Update()
    {
        ShowTransformInfo();
    }

     void ShowTransformInfo()
    {
        _text.text = "Position " + _obj.transform.position +
                     "\nRotation " + _obj.transform.rotation +
                     "\nScale " + _obj.transform.localScale;
    }
}
