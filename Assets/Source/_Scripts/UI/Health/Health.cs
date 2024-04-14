using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float currentValue = 100;
    public float maxValue = 100;
    public UnityAction<float> HealthChanged = delegate { };

    public float Increase(float amount)
    {
        currentValue += amount;
        if (currentValue > maxValue) currentValue = maxValue;
        HealthChanged.Invoke(currentValue);
        return currentValue;
    }

    public float Decrease(float amount)
    {
        currentValue -= amount;
        if (currentValue < 0) currentValue = 0;
        HealthChanged.Invoke(currentValue);
        return currentValue;
    }
}