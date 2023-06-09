using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class CharacterMove : MonoBehaviour
{
    [HideInInspector][SerializeField] private CharacterController _character;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed = 3;
    [SerializeField] private float _jumpForce = 5;
   
    private bool _isAlive = true;

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
        var jump = Input.GetAxis("Jump");

        if (_isAlive)
        {
            transform.Rotate(Vector3.up, horizontal*2);

            Move(horizontal, vertical, jump);

            if (Input.GetMouseButtonDown(0)) _animator.SetTrigger("IsPunching");
        }
    }


    private void Move(float horizontal, float vertical, float jump)
    {
            var runMultiplicator = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;

            var dir = new Vector3(horizontal, 0, vertical);
            var speed = _moveSpeed * runMultiplicator;
            var moveVector = transform.TransformDirection(dir) * speed;

            _animator.SetBool("IsWalking", horizontal != 0 || vertical != 0);
            _animator.SetFloat("Move Speed", speed / (_moveSpeed * 2));


            if (_character.isGrounded)
            {
                if (_velocity.y < 0)
                {
                    _velocity.y = 0;
                }

                if (jump != 0)
                {
                    _velocity.y += _jumpForce;
                _animator.SetTrigger("IsJumping");
            }
            }

            _velocity.y += -9.81f * Time.deltaTime;

            _character.Move((moveVector + _velocity) * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider collision)
    {
        _animator.SetTrigger("IsDying");
        _isAlive = false;
    }

}
