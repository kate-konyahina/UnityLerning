using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TopDownZenject
{
    public class FirstCutscene : MonoBehaviour
    { 
        void Start()
        {
            StartCoroutine(LoadMainScene());
        }

        IEnumerator LoadMainScene()
        {
            yield return new WaitForSeconds(6);
            SceneManager.LoadScene(1);
        }
    }
}
