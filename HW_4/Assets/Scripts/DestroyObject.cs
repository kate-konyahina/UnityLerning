using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Target" || other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
        }
    }
}
