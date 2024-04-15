using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private List<GameObject> _itemPrefabs;

    private Animator _animator;
    private bool _isOpen;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OpenChest()
    {
        int count = 0;
        while (count < 3)
        {
            int index = GetRandomIndex();
            Instantiate(_itemPrefabs[index], 
                        transform.position + new Vector3(-0.5f, -0.5f),
                        Quaternion.identity);

            count++;
        }
    }

    private int GetRandomIndex()
    {
        return Random.Range(0, _itemPrefabs.Count);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null && !_isOpen)
        {
            _animator.SetTrigger("IsOpen");
            _isOpen = true;
        }
    }

   
}
