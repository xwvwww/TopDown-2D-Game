using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private InputHandler _input;

    [Header("Move Parameters")]
    [Tooltip("Move speed")]
    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _rb;
    private Animator _animator;
    private Inventory _inventory;
    private int _countCoin;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = _input.MoveInput.x * transform.right +
                            _input.MoveInput.y * transform.up;

        if (direction.magnitude > 1f)
            direction.Normalize();

        _rb.velocity = new Vector2(direction.x, 
                                   direction.y) * 
                                   _moveSpeed;

        _animator.SetFloat("Speed", direction.magnitude);

        if (direction.magnitude > 0f)
        {
            _animator.SetFloat("VelocityX", direction.x);
            _animator.SetFloat("VelocityY", direction.y);
        }
    }

   
}
