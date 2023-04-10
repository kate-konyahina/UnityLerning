using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    [SerializeField] Vector3 DestinationPosition;
    Vector3 StartPosition;
    bool DestinationReached;
    bool InStartPosition;

    private void Start()
    {
       StartPosition = transform.position;
    }
    
    void Update()
    {
       if (InStartPosition)
        {
           MoveForward();
        }

       if (DestinationReached)
        {
           MoveBack();
        }

        if (transform.position.y <= StartPosition.y + 0.1f)
        {
          InStartPosition = true;
          DestinationReached = false; 
        }

       if (transform.position.y >= DestinationPosition.y - 0.1f)
        {
           DestinationReached = true;
           InStartPosition = false;
        }
    }

    void MoveForward ()
    {
        transform.position = Vector3.Lerp(transform.position, DestinationPosition, Time.deltaTime);
    }

    void MoveBack()
    {
        transform.position = Vector3.Lerp(transform.position, StartPosition, Time.deltaTime);
    }
}
