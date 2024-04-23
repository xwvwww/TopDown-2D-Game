using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemContainer : MonoBehaviour, IPointerClickHandler
{
    private Item _item;
    private int _countItem;
    private bool _isBusy;
    private TextMeshProUGUI _text;
    private Image _iconItem;

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

    public TextMeshProUGUI Text
    {
        get { return _text; }
        set { _text = value; }
    }

    public Image IconItem
    {
        get { return _iconItem; }
        set { _iconItem = value; }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_item != null)
        {
            if (_countItem > 0)
            {
                if (_item.Use())
                {
                    _countItem--;

                    _text.text = _countItem.ToString();

                    if (_countItem == 0)
                    {
                        _text.text = "";
                        _item = null;
                        _isBusy = false;
                        _iconItem.sprite = null;
                        _iconItem.color = new Color(255f, 255f, 255f, 0f);
                    }
                }
                
            }
        }
    }
    public void Init()
    {
        _text = transform.Find("Amount").GetComponent<TextMeshProUGUI>();
        _iconItem = transform.Find("Icon").GetComponent<Image>();
    }
}
