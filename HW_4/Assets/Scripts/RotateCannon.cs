using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateCannon : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] GameObject _obj;
    [SerializeField] Vector3 _rotateVector;
    private bool rotate = false;
     
    public void Update()
    {
       if (rotate) _obj.transform.Rotate(_rotateVector);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rotate = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rotate = false;
    }
}
