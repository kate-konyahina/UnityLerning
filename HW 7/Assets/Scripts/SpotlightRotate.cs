using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightRotate : MonoBehaviour
{
    void Update()
    {
        var mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.right, mouseY);
    }
}
