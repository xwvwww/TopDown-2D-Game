using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/NewItem", fileName = "New Item")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private ItemType _itemType;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public Sprite Icon
    {
        get { return _icon; }
        set { _icon = value; }
    }

    public ItemType ItemType
    {
        get { return _itemType; }
        set { _itemType = value; }
    }
}

public enum ItemType
{
    Health
}
