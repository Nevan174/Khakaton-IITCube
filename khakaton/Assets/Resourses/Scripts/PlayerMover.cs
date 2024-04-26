using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Inputs _inputs;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _mouseSens;
    [SerializeField] private CharacterController _characterController;

    private Rigidbody _rb;
    private Camera _camera;
    private Vector3 _rotation;
    private float _xRotation = 0;
    private float _yRotation = 0;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _camera = Camera.main;

        _inputs.jumpEvent.AddListener(OnJump);
    }


    void Update()
    {
        OnMove();
        OnLook();

    }

    private void OnMove()
    {

        _rb.AddRelativeForce(new Vector3(_inputs.move.x, 0, _inputs.move.y) * _speed * Time.deltaTime); ;
        if (_inputs.move == Vector2.zero)
        {
            _rb.velocity = Vector3.zero;
        }

    }
    private void OnLook()
    {
        _xRotation -= _mouseSens * _inputs.look.y;
        _xRotation = Mathf.Clamp(_xRotation, -60f, 30f);

        _yRotation += _inputs.look.x * _mouseSens;

        _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, _yRotation, 0);
    }

    private void OnJump()
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }
}
