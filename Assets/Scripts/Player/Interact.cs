using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private LayerMask _interactLayer;

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.IsTouchingLayers(_interactLayer))
        {
            print(collision.name);
        }
    }
}
