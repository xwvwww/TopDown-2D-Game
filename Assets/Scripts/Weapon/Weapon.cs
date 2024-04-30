using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float _attackDelay;
    [SerializeField] protected float _damage;

    protected Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public abstract void Attack();
  
}
