using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLeft : MonoBehaviour
{
    [SerializeField] GameObject _obj;

    public void OnButtonLeftPressed()
    {
        _obj.transform.Rotate(Vector3.down);
    }
}
