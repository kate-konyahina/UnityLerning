using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeDecrease : MonoBehaviour
{
    [SerializeField] GameObject obj;

    public void OnButtonSDPressed()
    {
        obj.transform.localScale -= new Vector3(1, 1, 1);
    }
}
