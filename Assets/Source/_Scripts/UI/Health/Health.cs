using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _currentValue;
    [SerializeField] private float _maxValue;

    public UnityAction<float> HealthChanged = delegate { };

    public float Increase(float amount)
    {
        _currentValue += amount;
        if (_currentValue > _maxValue)
        {
            _currentValue = _maxValue;
        }
        HealthChanged.Invoke(_currentValue);
        return _currentValue;
    }

    public float Decrease(float amount)
    {
        _currentValue -= amount;
        if (_currentValue < 0)
        {
            _currentValue = 0;
        }
        HealthChanged.Invoke(_currentValue);
        return _currentValue;
    }
}
