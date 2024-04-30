using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : Item
{
    public override bool Use()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
        {
            if (playerHealth.CurrentHealth < playerHealth.MaxHealth)
            {
                playerHealth.AddHealth(20);
                return true;
            }

            return false;
        }

        return false;
    }
}
