using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance { get; private set; }
    private PlayerInput _playerInput;

    public Vector2 MoveInput { get; private set; }
    public Vector2 CursorPosition { get; private set; }
    public UnityAction InventoryPress { get; set; }
    public UnityAction InteractPress { get; set; }
    public bool ShootPress { get; private set; }
    public bool ReloadPress { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        if(_playerInput == null)
            _playerInput = new PlayerInput();
        
        DontDestroyOnLoad(this);

        _playerInput.Player.Move.performed += OnMove;
        _playerInput.Player.Move.canceled += OnMove;

        _playerInput.Player.Inventory.started += OnInventory;

        _playerInput.Player.Interact.started += OnInteract;

        _playerInput.Player.CursorPosition.performed += OnCursorPosition;

        _playerInput.Player.Shoot.performed += OnShoot;
        _playerInput.Player.Shoot.canceled += OnShoot;

        _playerInput.Player.Reload.started += OnReload;
        _playerInput.Player.Reload.canceled += OnReload;

    }

    private void OnReload(InputAction.CallbackContext context)
    {
        ReloadPress = context.ReadValueAsButton();
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        ShootPress = context.ReadValueAsButton();
    }

    private void OnCursorPosition(InputAction.CallbackContext context)
    {
        CursorPosition = context.ReadValue<Vector2>();
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        InteractPress?.Invoke();
    }

    private void OnInventory(InputAction.CallbackContext context)
    {
        InventoryPress?.Invoke();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
}
