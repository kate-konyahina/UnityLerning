using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField] bool RotateByX;
    [SerializeField] bool RotateByY;
    [SerializeField] bool RotateByZ;
    [SerializeField] int speed = 40;
    
    void Start()
    {
        RotateByZ = false;
        RotateByY = false;
        RotateByX = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (RotateByX)
        {
            transform.Rotate(Vector3.right * Time.deltaTime * speed);
        }

        if(RotateByY)
        {
            transform .Rotate(Vector3.up * Time.deltaTime * speed);
        }

        if(RotateByZ)
        {
            transform.transform.Rotate(Vector3.up * Time.deltaTime * speed);
        }
    }
}
