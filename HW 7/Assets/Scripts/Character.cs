using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class Character : MonoBehaviour
{
    [HideInInspector][SerializeField] private CharacterController _character;
    [SerializeField] private float _moveSpeed = 3;
    [SerializeField] private AudioSource _step;
    [SerializeField] private AudioSource _run;

    private Vector3 _velocity = Vector3.zero;

    private void OnValidate()
    {
        _character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var mouse = Input.GetAxis("Mouse X");
               
            transform.Rotate(Vector3.up, mouse);

            Move(horizontal, vertical);
    }


    private void Move(float horizontal, float vertical)
    {
        var runMultiplicator = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;

        var dir = new Vector3(horizontal, 0, vertical);
        var speed = _moveSpeed * runMultiplicator;
        var moveVector = transform.TransformDirection(dir) * speed;

        _velocity.y += -9.81f * Time.deltaTime;

       if (!Input.GetKey(KeyCode.LeftShift) && (Input.GetButton("Vertical") || Input.GetButton("Horizontal")))
        {
           if (!_step.isPlaying)
          {
                _step.Play();
           }
        }
        else
        {
           _step.Stop();
        }

        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetButton("Vertical") || Input.GetButton("Horizontal")))
        {
            if (!_run.isPlaying)
            {
                _run.Play();
            }
        }
        else
        {
            _run.Stop();
        }

        _character.Move((moveVector + _velocity) * Time.deltaTime);
    }
}
