using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed = 4;
    Transform target;
  
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, 0, target.position.z), speed * Time.deltaTime);
    }
}
