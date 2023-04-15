using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRight : MonoBehaviour
{
    [SerializeField] GameObject _obj;

    public void OnButtonRightPressed()
    {
        _obj.transform.Rotate(Vector3.up);
    }
}
