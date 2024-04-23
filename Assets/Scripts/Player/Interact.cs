using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private LayerMask _interactLayer;
    [SerializeField] private InputHandler _inputHandler;

    private Collider2D _collider;
    private GameObject _interactObject;
    private Inventory _inventory;
    private bool _canInteract;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        if (_interactObject != null)
        {
            if (_inputHandler.InteractPress)
            {
                if (_interactObject.tag == "Chest")
                {
                    _inventory.GetItem(ItemType.Key);
                }
            }
        }
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


}
