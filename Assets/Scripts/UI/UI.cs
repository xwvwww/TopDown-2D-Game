using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private InputHandler _input;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private Interact _interact;
    [SerializeField] private GameObject _inventory;
    [SerializeField] private TextMeshProUGUI _toolTipText;

    private void Start()
    {
        _healthSlider.minValue = 0f;
        _healthSlider.maxValue = _health.MaxHealth;
        _healthSlider.value = _health.MaxHealth;

    }

    private void ChangeHPSlider(int hp)
    {
        _healthSlider.value = hp;
    }

    private void ChangeToolTipText(string text)
    {
        _toolTipText.text = text;
    }

    private void OnEnable()
    {
        _health.OnHealth += ChangeHPSlider;
        _input.InventoryPress += SetActiveInventory;
        _interact.OnToolTip += ChangeToolTipText;
    }

    private void SetActiveInventory()
    {
        _inventory.SetActive(!_inventory.activeSelf);
    }

    private void OnDisable()
    {
        _health.OnHealth -= ChangeHPSlider;
    }
}
