using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private LayerMask _interactLayer;
    [SerializeField] private InputHandler _inputHandler;


    private GameObject _interactObject;
    private Inventory _inventory;
    private bool _canInteract = true;

    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
      
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Chest")
        {
            _interactObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
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

            if (_interactObject.tag == "Chest")
            {
                var container = _inventory.GetItem(ItemType.Key);
                if (container != null)
                {
                    _interactObject.GetComponentInParent<Chest>().ActiveChest((KeyItem)container.Item);
                    container.UseItem();
                    _canInteract = false;
                }
            }
        }
    }
}
