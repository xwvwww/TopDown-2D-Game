using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemContainer : MonoBehaviour, IPointerClickHandler
{
    private Item _item;
    private bool _isBusy;

    public Item Item
    {
        get { return _item; }
        set { _item = value; }
    }

    public bool IsBusy
    {
        get { return _isBusy; }
        set { _isBusy = value; }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_item != null)
        {
            _item.Use();
        }
    }
}
