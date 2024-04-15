using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    private event UnityAction<int> _onHealth;

    public event UnityAction<int> OnHealth
    {
        add { _onHealth += value; }
        remove { _onHealth -= value; }
    }

    public override void AddHealth(int hp)
    {
        base.AddHealth(hp);
        _onHealth.Invoke(_currentHealth);
    }

    public override void Damage(int dmg)
    {
        base.Damage(dmg);
        _onHealth.Invoke(_currentHealth);

        if (_currentHealth <= 0)
        {

        }
    }
}
