using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{

    public GunBob GunBob;
    public HeadBobber HeadBobber;

    private float _gunBobAmplitude = 0.1f;
    private float _headBobSpeed = 0.18f;
    private float _headBobAmount = 0.2f;

    public float MovementSpeed = 3.0f;
    public float SprintActive = 0;
    public float Gravity = -9.81f;

    private CharacterController _characterController;

    private float _movementH, _movementV;
    private float _movementSpeed;
    public bool _isWalking = false;
    

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        //Sprint (Sprint axis je namjesten u unity Input)
        SprintActive = Input.GetAxisRaw("Sprint");
        if (SprintActive == 0)
        {
            _movementSpeed = MovementSpeed;
        }
        /*else
        {
            _movementSpeed = MovementSpeed * 3;
        }*/

        //Movement
        _movementH = Input.GetAxisRaw("Horizontal");
        _movementV = Input.GetAxisRaw("Vertical");
        MoveMe();

        if ((_movementH != 0 || _movementV != 0)) {
            
            _isWalking = true;
        }
        else
        {
            _isWalking = false;
        }

        if (_isWalking)
        {
            GunBob._isMoving = true;
        }
        else
        {
            GunBob._isMoving = false;
        }
    }


    public void MoveMe()
    {
        Vector3 movementX = _movementH * Vector3.right;
        Vector3 movementZ = _movementV * Vector3.forward;

        Vector3 movement = movementX + movementZ;
        movement.Normalize();
        movement *= _movementSpeed * Time.deltaTime;

        movement.y = Gravity * Time.deltaTime;

        movement = transform.TransformDirection(movement);

        _characterController.Move(movement);
    }
}