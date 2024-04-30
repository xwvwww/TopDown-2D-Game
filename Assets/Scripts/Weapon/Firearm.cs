using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Firearm : Weapon
{
    [SerializeField] private int _clipSize;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _reloadingTime;
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Transform _weaponHolder;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;

    private Camera _camera;
    private Vector3 _aimDirection;
    private Vector3 _worldCursorPosition;

    private int _currentClipSize;
    private float _shootLastTime;
    private bool _isReloading;

    private void Awake()
    {
        _camera = Camera.main;
    }

    void Start()
    {
        _currentClipSize = _clipSize;
    }

    void Update()
    {
        Aim();
        Attack();
    }

    public override void Attack()
    {
        if (_inputHandler.ShootPress && _currentClipSize > 0)
        {
            if ((Time.time - _shootLastTime) < _attackDelay)
                return;

            _shootLastTime = Time.time;
            _currentClipSize--;

            GameObject bullet = Instantiate(_bulletPrefab, 
                                            _shootPoint.position, 
                                            Quaternion.identity);

            bullet.GetComponent<Rigidbody2D>().velocity = _aimDirection * _bulletSpeed;
        }
    }

    public void Aim()
    {
        _worldCursorPosition = _camera.ScreenToWorldPoint(_inputHandler.CursorPosition);
        _aimDirection = (_worldCursorPosition - transform.position).normalized;

        float angle = Mathf.Atan2(_aimDirection.y, _aimDirection.x) * Mathf.Rad2Deg;
        _weaponHolder.eulerAngles = new Vector3(0f, 0f, angle);
    }

    private void Reload()
    {
        _isReloading = true;
        StartCoroutine(ReloadingDelay());
    }

    private IEnumerator ReloadingDelay()
    {
        yield return new WaitForSeconds(_reloadingTime);
        _isReloading = false;
        _currentClipSize = _clipSize;
    }
}
