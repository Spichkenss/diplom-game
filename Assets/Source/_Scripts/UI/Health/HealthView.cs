using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TMP_Text _healthTextAmount;
    
    [SerializeField] private Color _lowHealthColor = Color.HSVToRGB(0, 100, 90); // red
    [SerializeField] private Color _midHealthColor = Color.HSVToRGB(39, 100, 100); // orange
    [SerializeField] private Color _highHealthColor = Color.HSVToRGB(120, 100, 80); // green

    private Image _healthFillImage;

    private void Awake()
    {
        _healthFillImage = _healthSlider.fillRect.GetComponent<Image>();
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnHealthChanged(float newValue)
    {
        _healthSlider.value = newValue / _health.maxValue;
        _healthTextAmount.text = newValue.ToString();

        var healthPercentage = newValue / _health.maxValue * 100;
        var color = healthPercentage switch
        {
            <= 10 => _lowHealthColor,
            > 10 and < 60 => _midHealthColor,
            _ => _highHealthColor
        };
        _healthFillImage.color = color;
    }
}