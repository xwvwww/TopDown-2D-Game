using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : Item
{
    public override bool Use()
    {
        Debug.Log("Key");
        return true;
    }
}
