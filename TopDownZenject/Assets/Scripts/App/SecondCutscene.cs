using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownZenject
{
    public class SecondCutscene : MonoBehaviour
    {
        void Start()
        {
            StartCoroutine(QuitGame());
        }

        IEnumerator QuitGame()
        {
            yield return new WaitForSeconds(6);
            Application.Quit();
        }
    }
}
