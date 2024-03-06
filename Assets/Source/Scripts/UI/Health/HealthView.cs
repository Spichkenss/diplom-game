using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TMP_Text _healthTextAmount;

    private void Awake()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnHealthChanged(float newValue)
    {
        _healthSlider.value = newValue;
        _healthTextAmount.text = newValue.ToString();
    }
}
