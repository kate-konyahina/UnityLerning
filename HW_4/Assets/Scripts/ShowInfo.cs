using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShowInfo : MonoBehaviour
{
    [SerializeField] Fire _fire;
    [SerializeField] TextMeshProUGUI _text;

    private void Update()
    {
        ShowTransformInfo();
    }

    void ShowTransformInfo()
    {
        _text.text = "Targets count: " + GameObject.FindGameObjectsWithTag("Target").Length +
                     "\nShot strength (Max 3000): " + _fire.force;
    }
}
