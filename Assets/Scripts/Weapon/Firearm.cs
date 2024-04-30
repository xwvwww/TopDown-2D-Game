using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firearm : Weapon
{

    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Transform _weaponHolder;
    [SerializeField] private GameObject _bulletPrefab;

    private Camera _camera;
    private Vector3 _aimDirection;
    private Vector3 _worldCursorPosition;

    private void Awake()
    {
        _camera = Camera.main;
    }

    void Start()
    {
        
    }

    void Update()
    {
        Aim();
    }

    public override void Attack()
    {

    }

    public void Aim()
    {
        _worldCursorPosition = _camera.ScreenToWorldPoint(_inputHandler.CursorPosition);
        _aimDirection = (_worldCursorPosition - transform.position).normalized;

        float angle = Mathf.Atan2(_aimDirection.y, _aimDirection.x) * Mathf.Rad2Deg;
        _weaponHolder.eulerAngles = new Vector3(0f, 0f, angle);
    }
}
