using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interact : MonoBehaviour
{
    [SerializeField] private LayerMask _interactLayer;
    [SerializeField] private InputHandler _inputHandler;


    private event UnityAction<string> _onToolTip;
    private GameObject _interactObject;
    private Inventory _inventory;
    private bool _canInteract = true;

    public event UnityAction<string> OnToolTip
    {
        add { _onToolTip += value; }
        remove { _onToolTip -= value; }
    }

    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Chest")
        {
            _onToolTip?.Invoke("Press 'E to interact");
            _interactObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _onToolTip?.Invoke("");
        _interactObject = null;
    }

    private void OnEnable()
    {
        _inputHandler.InteractPress += InteractWithItem;
    }

    private void InteractWithItem()
    {
        if (_interactObject != null)
        {
            Chest chest = _interactObject.GetComponentInParent<Chest>();
            if (chest != null && chest.IsOpen == false)
            {
                var container = _inventory.GetItem(ItemType.Key);
                if (container != null)
                {
                    chest.ActiveChest((KeyItem)container.Item);
                    container.UseItem();
                    _onToolTip?.Invoke("");
                }
                else
                {
                    _onToolTip?.Invoke("Key not found");
                }
            }
        }
    }
}
