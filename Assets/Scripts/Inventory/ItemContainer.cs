using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemContainer : MonoBehaviour, IPointerClickHandler
{
    private Item _item;
    private int _countItem;
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

    public int CountItem
    {
        get { return _countItem; }
        set { _countItem = value; }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_item != null)
        {
            if (_countItem > 0)
            {
                _item.Use();
                _countItem--;
            }
            else
            {
                _isBusy = false;
                _item = null;
            }
        }
    }
}
