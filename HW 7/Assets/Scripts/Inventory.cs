using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject keyImage;
    [SerializeField] GameObject slot;
    [SerializeField] private bool withKey = false;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
          Instantiate(keyImage, slot.transform);
          Destroy(other.gameObject); 
           withKey = true;
        }

        if (other.CompareTag("Door") && withKey)
        {
            SceneManager.LoadScene(2);
        }

        if (other.CompareTag("Spawn") && withKey)
        {
            Instantiate(enemy, spawnPoint);
        }

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Collision");
            SceneManager.LoadScene(3);
        }
    }
}
