using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSizeChange : MonoBehaviour
{
    [SerializeField] Vector3 MaxSize;
    [SerializeField] Vector3 MinSize;
    bool MinSizeReached;
    bool MaxSizeReached;
    Vector3 ScaleChange;

    
    void Update()
    {
       if (MinSizeReached)
        {
            SizeIncrease();
        }
     
        if (MaxSizeReached)
        {
           SizeDecreace();
        }

        if (transform.localScale.x <= MinSize.x)
        {
           MinSizeReached = true;
           MaxSizeReached = false;
        }
       if (transform.localScale.x >= MaxSize.x)
        {
           MaxSizeReached = true;
           MinSizeReached = false;
        }
    }

    void SizeIncrease()
    {
        Vector3 ScaleChange = new Vector3(1, 1, 1) * Time.deltaTime;
        transform.localScale += ScaleChange;
    }

    void SizeDecreace()
    {
        Vector3 ScaleChange = new Vector3(1, 1, 1) * Time.deltaTime;
        transform.localScale -= ScaleChange;
    }
}
