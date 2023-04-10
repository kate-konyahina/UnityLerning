using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject [] _gameObject;
    
    void Update()
    { 
        int randomIndex = Random.Range(0, _gameObject.Length);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_gameObject[randomIndex], transform.position, Quaternion.identity);
        }
    }
    //new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5))
}
