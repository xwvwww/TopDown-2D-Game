using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : Item
{
    public override bool Use()
    {
        PlayerHealth playerhealth = FindObjectOfType<PlayerHealth>();
        
        if (playerhealth != null)
        {
            if (playerhealth.CurrentHealth < playerhealth.MaxHealth)
            {
                playerhealth.AddHealth(20);
                return true;
            }

            return false;
        }

        return false;
    }
}
