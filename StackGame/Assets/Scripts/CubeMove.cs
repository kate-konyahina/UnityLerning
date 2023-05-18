using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeMove : MonoBehaviour
{
    [SerializeField] Vector3 DestinationPosition;
    [SerializeField] Vector3 StartPosition;
    [SerializeField] GameObject _pauseMenuUI;
    [SerializeField] public float speed = 6f;
    bool DestinationReached;
    bool InStartPosition;


    public static CubeMove PreviousCube { get; private set; }
    public static CubeMove CurrentCube { get; set; }

    private void Start()
    {
        if (PreviousCube == null) PreviousCube = GameObject.Find("Base").GetComponent<CubeMove>();

        CurrentCube = this;

        GetComponent<Renderer>().material.color = RandomColor();
        transform.localScale = new Vector3(PreviousCube.transform.localScale.x, transform.localScale.y, PreviousCube.transform.localScale.z);

    }

    void Update()
    {
        if (InStartPosition)
        {
            MoveForward();
        }

        if (DestinationReached)
        {
            MoveBack();
        }

        if (transform.position.x <= StartPosition.x + 0.1f)
        {
            InStartPosition = true;
            DestinationReached = false;
        }

        if (transform.position.x >= DestinationPosition.x - 0.1f)
        {
            DestinationReached = true;
            InStartPosition = false;
        }
       
    }

    void MoveForward()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    void MoveBack()
    {
        transform.position -= transform.right * Time.deltaTime * speed;
    }

    public void Stop ()
    {
        speed = 0;
        float difference = transform.position.x - PreviousCube.transform.position.x;

        if (Mathf.Abs(difference) >= PreviousCube.transform.localScale.x)
        {
            PauseMenu.GameIsFinished = true;
            Time.timeScale = 0f;
        }

        float direction = difference > 0 ? 1 : -1;

       SplitOnX(difference, direction);
        PreviousCube = this;
    }
    
    void SplitOnX(float difference, float direction)
    {
        float newSize = PreviousCube.transform.localScale.x - Mathf.Abs(difference);
        float fallingCubeSize = transform.localScale.x - newSize;

        float newXPosition = PreviousCube.transform.position.x + (difference / 2);
        transform.localScale = new Vector3 (newSize, transform.localScale.y, transform.localScale.z);
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);

        float cubeEdge = transform.position.x + (newSize / 2 * direction);
        float fallingCubeXPosition = cubeEdge + (fallingCubeSize / 2 * direction);

        SpawnFallingCube(fallingCubeXPosition, fallingCubeSize);
       
    }

    void SpawnFallingCube(float fallingCubeXPosition, float fallingCubeSize)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = new Vector3(fallingCubeSize, transform.localScale.y, transform.localScale.z);
        cube.transform.position = new Vector3(fallingCubeXPosition, transform.position.y, transform.position.z);

        cube.AddComponent<Rigidbody>();
        cube.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
        Destroy(cube.gameObject, 2);
    }

    private Color RandomColor()
    {
        return new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }
}
