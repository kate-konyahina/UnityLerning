using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ChangeColor : MonoBehaviour
{

    private MeshRenderer _mesh;
    void Awake()
    {
        _mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)) 
            {
            MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
            Color color = Color.Lerp(Color.red, Color.green, Random.Range(0f, 1f));
            materialPropertyBlock.SetColor("_Color", color);
            _mesh.SetPropertyBlock(materialPropertyBlock);
        }
    }
}
