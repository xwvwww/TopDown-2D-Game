using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemData _itemData;
    [SerializeField] private int _amount;

    public ItemData ItemData
    {
        get { return _itemData; }
        set { _itemData = value; }
    }

    public int Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }

    public virtual bool Use()
    {
        return true;
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
