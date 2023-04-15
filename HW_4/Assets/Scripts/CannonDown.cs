using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonDown : MonoBehaviour
{
    [SerializeField] GameObject _obj;

    public void OnButtonDownPressed()
    {
        _obj.transform.Rotate(Vector3.right);
    }
}
