using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Fire : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject cannon;
    [SerializeField] private GameObject bullet;
    [SerializeField] public float force = 1f;
    [SerializeField] float speed = 500f;
    [SerializeField] float maxForce = 3000f;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            force += Time.deltaTime * speed; 
            if (force > maxForce) force = maxForce;
        }

        if (Input.GetMouseButtonUp(1))
        {
            GameObject _bullet = Instantiate(bullet, shootPoint.position, Quaternion.identity);
            _bullet.GetComponent<Rigidbody>().AddForce(cannon.transform.forward * force, ForceMode.Force);
            force = 0;
        }

    }
}
