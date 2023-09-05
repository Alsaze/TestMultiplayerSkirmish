using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using Mirror;
using System;

public class TestingInputSystem : NetworkBehaviour
{
    [SerializeField] private GameObject belfry;
    [SerializeField] private GameObject gun;
    private Gun _gun;
    
    private Rigidbody2D _rb;
    private PlayerInput _playerInput;
    private PlayerInputAction _playerInputAction;
    private bool _isAuthority = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _gun = gun.GetComponent<Gun>();

        _playerInputAction = new PlayerInputAction();
        _playerInputAction.Enable();

        _playerInputAction.Player.Fire.performed += Fire;
    }

    private void Fire(InputAction.CallbackContext context)
    {
        if (context.performed && _isAuthority)
        {
            _gun.TryToShot();
        }
    }

    private void FixedUpdate()
    {
        if (_isAuthority)
        {
            Vector2 inputVector2 = _playerInputAction.Player.Movment.ReadValue<Vector2>();
            float moveSpeed = 1.5f;
            _rb.velocity = inputVector2 * moveSpeed;
        
            if (inputVector2!=Vector2.zero)
            {
                PlayerDirection(inputVector2);
            }
        }
    }
    
    private void PlayerDirection(Vector3 inputVector2)
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward,
            inputVector2);
    }

    private void Update()
    {
        if (_isAuthority)
        {
            Vector2 inputVector2 = _playerInputAction.Player.BelfryRotation.ReadValue<Vector2>();
            if (inputVector2 != Vector2.zero)
            {
                BelfryDirection(inputVector2);
            }
        }
    }

    private void BelfryDirection(Vector2 inputVector2)
    {
        Vector3 inputVector3 = new Vector3(inputVector2.x, inputVector2.y, 0); 
        belfry.transform.rotation = quaternion.LookRotation(Vector3.forward,
            inputVector3);
    }

    public override void OnStartAuthority()
    {
        _isAuthority = true;
    }
}
