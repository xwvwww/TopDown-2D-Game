using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private List<GameObject> _itemPrefabs;

    private Animator _animator;
    private bool _isOpen;

    public bool IsOpen => _isOpen;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ActiveChest(KeyItem key)
    {
        if  (key != null)
        {
            _isOpen = true;
            _animator.SetTrigger("IsOpen");
        }
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
}
