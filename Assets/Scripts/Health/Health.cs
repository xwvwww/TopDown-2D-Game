using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int _health;

    protected int _currentHealth;

    public int MaxHealth => _health;

    private void Start()
    {
        _currentHealth = _health;
    }

    public virtual void Damage(int dmg)
    {
        _currentHealth -= dmg;
    }

    public virtual void AddHealth(int hp)
    {
        _currentHealth += hp;
        if (_currentHealth > _health)
            _currentHealth = _health;
    }
}
