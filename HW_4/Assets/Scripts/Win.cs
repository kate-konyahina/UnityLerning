using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] GameObject[] targets;
    [SerializeField] GameObject _field;
    void Update()
    {
        if (targets.All(target => target.transform.position.y <= _field.transform.position.y))
        {
            SceneManager.LoadScene(1);
        }
    }
}
