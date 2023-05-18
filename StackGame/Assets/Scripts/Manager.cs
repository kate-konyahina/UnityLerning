using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] TextMeshProUGUI _text;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CubeMove.CurrentCube != null)
               CubeMove.CurrentCube.Stop();

            FindObjectOfType<CubeSpawner>().SpawnCube();
           
            _camera.transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y + 0.75f, _camera.transform.position.z);
            ShowInfo();
        }
    }
    void ShowInfo()
    {
        _text.text = (GameObject.FindGameObjectsWithTag("Cube").Length - 1).ToString();
    }
}
