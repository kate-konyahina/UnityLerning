using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonUp : MonoBehaviour
{
    [SerializeField] GameObject _obj;

    public void OnButtonUpPressed()
    {
        _obj.transform.Rotate(Vector3.left);
    }
}
