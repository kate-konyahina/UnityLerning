using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTeleportation : MonoBehaviour
{
    [SerializeField] int XMinTeleportRange = -5, XMaxTeleportRange = 5;
    [SerializeField] int YMinTeleportRange = -5, YMaxTeleportRange = 5;
    [SerializeField] int ZMinTeleportRange = -5, ZMaxTeleportRange = 5;
    [SerializeField] float TeleportPerXSecond = 2;
    float timeCount;

    void Update()
    {
        timeCount += Time.deltaTime;

        if(timeCount >= TeleportPerXSecond)
        {
            transform.position = new Vector3(Random.Range(XMinTeleportRange, XMaxTeleportRange), 
                Random.Range(YMinTeleportRange, YMaxTeleportRange), Random.Range(ZMinTeleportRange, ZMaxTeleportRange));
            timeCount = 0;
        }
    }
}
