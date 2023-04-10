using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeIncrease : MonoBehaviour
{
    [SerializeField] GameObject obj;

    public void OnButtonSIPressed()
    {
        obj.transform.localScale += new Vector3(1, 1, 1);
    }
}
