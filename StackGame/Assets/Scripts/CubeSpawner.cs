using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubeMove cubePrefab;
    [SerializeField] AudioSource _spawn;

    public void SpawnCube()
    {
        if (!PauseMenu.GameIsFinished)
        {
            var cube = Instantiate(cubePrefab);
            _spawn.Play();
            if (cubePrefab.speed < 10)
            {
                cubePrefab.speed = cube.speed + 0.5f;
            }

            if (CubeMove.PreviousCube != null && CubeMove.PreviousCube.gameObject != GameObject.Find("Base"))
            {
                cube.transform.position = new Vector3(transform.position.x, CubeMove.PreviousCube.transform.position.y + cubePrefab.transform.localScale.y, transform.position.z);
            }
            else
            {
                cube.transform.position = transform.position;
            }
        }
    }
}
