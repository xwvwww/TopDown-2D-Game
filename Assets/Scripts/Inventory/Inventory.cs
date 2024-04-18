using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    private List<ItemContainer> _containers;

    private void Awake()
    {
        _containers = new List<ItemContainer>();
        for(int i = 0; i < _parent.childCount; i++)
        {
            _containers.Add(_parent.GetChild(i).GetComponent<ItemContainer>());
        }
    }

    public void AddItem(Item item)
    {
        if (item == null)
            return;

        foreach (ItemContainer container in _containers)
        {
            if (!container.IsBusy)
            {
                Image icon = container.transform.Find("Icon").GetComponent<Image>();
                TextMeshProUGUI amountText = container.transform.Find("Amount").GetComponent<TextMeshProUGUI>();

                icon.sprite = item.ItemData.Icon;
                icon.color = new Color(255f, 255f, 255f, 255f);
                amountText.text = item.Amount.ToString();

                container.Item = item;
                container.IsBusy = true;

                break;
            }
        }
    }
}
