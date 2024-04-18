using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private InputHandler _input;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private GameObject _inventory;

    private void Start()
    {
        _healthSlider.minValue = 0f;
        _healthSlider.maxValue = _health.MaxHealth;
        _healthSlider.value = _health.MaxHealth;
    }

    private void Update()
    {
        if (_input.InventoryPress)
        {
            _inventory.SetActive(true);
        }
        else
        {
            _inventory.SetActive(false);
        }
    }

    private void ChangeHPSlider(int hp)
    {
        _healthSlider.value = hp;
    }

    private void OnEnable()
    {
        _health.OnHealth += ChangeHPSlider;
    }

    private void OnDisable()
    {
        _health.OnHealth -= ChangeHPSlider;
    }
}
