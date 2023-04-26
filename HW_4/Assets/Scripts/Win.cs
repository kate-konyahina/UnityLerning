using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Target").Length == 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
