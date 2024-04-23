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
    public bool InteractPress { get; private set; }
    public bool InventoryPress { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        if(_playerInput == null)
            _playerInput = new PlayerInput();
        
        DontDestroyOnLoad(this);

        _playerInput.Player.Move.performed += OnMove;
        _playerInput.Player.Move.canceled += OnMove;

        _playerInput.Player.Inventory.performed += OnInventory;
        _playerInput.Player.Inventory.canceled += OnInventory;

        _playerInput.Player.Interact.started += OnInteract;
        _playerInput.Player.Interact.canceled += OnInteract;
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        InteractPress = context.ReadValueAsButton();
    }

    private void OnInventory(InputAction.CallbackContext context)
    {
        InventoryPress = context.ReadValueAsButton();
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
